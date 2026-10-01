using NAudio.Dsp;
using NAudio.Wave;

namespace SoundCoreEngine.Audio
{
    /// <summary>
    /// Estimador de BPM por análisis de señal (no depende de los tags).
    ///
    /// Pasos:
    ///  1. Lee con NAudio un fragmento central de la pista (AnalysisSeconds) y lo pasa a mono.
    ///  2. Calcula el "spectral flux": cuánto aumenta la energía espectral (FFT, escala log)
    ///     entre ventanas consecutivas. Los golpes (kick, snare, hats) producen picos.
    ///  3. Resta la media local y rectifica, dejando solo los inicios de golpe (onsets).
    ///  4. Autocorrelaciona la envolvente: el lag con más correlación es el periodo del pulso.
    ///  5. Pondera con un prior centrado en 120 BPM para reducir errores de octava
    ///     (confundir 70 con 140, por ejemplo) y refina usando el pico del 4.º múltiplo.
    ///
    /// Limitación conocida: la ambigüedad de octava no se puede eliminar del todo
    /// (un tema a 174 BPM puede salir como 87). El rango válido es 60-200 BPM.
    /// </summary>
    public sealed class SpectralFluxBpmAnalyzer : IBpmAnalyzer
    {
        private const int FftLog2 = 10;
        private const int WindowSize = 1 << FftLog2;   // 1024 muestras
        private const int HopSize = 256;               // ~172 Hz de resolución de envolvente a 44.1 kHz

        private const double MinBpm = 60;
        private const double MaxBpm = 200;
        private const double PriorCenterBpm = 120;     // el prior favorece tempos cercanos a este valor

        private const double AnalysisSeconds = 45;     // fragmento central a analizar
        private const double MinAudioSeconds = 8;      // menos que esto no es confiable
        private const double LocalMeanSeconds = 0.4;   // ventana de la media local

        public Task<(int bpm, double confidence)?> EstimateBpmAsync(string filePath, CancellationToken ct = default)
            => Task.Run<(int bpm, double confidence)?>(() => Estimate(filePath, ct), ct);

        private static (int bpm, double confidence)? Estimate(string filePath, CancellationToken ct)
        {
            try
            {
                var (mono, sampleRate) = ReadMiddleFragment(filePath, ct);
                if (mono.Length < sampleRate * MinAudioSeconds) return null;

                double[] onsets = ComputeOnsetEnvelope(mono, sampleRate, ct);
                double frameRate = (double)sampleRate / HopSize;
                return PickTempo(onsets, frameRate);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception)
            {
                // Archivo corrupto, formato sin decodificador, sin permisos, etc.
                return null;
            }
        }

        // Lee el centro de la pista (evita intros/outros sin ritmo) y mezcla a mono.
        private static (float[] mono, int sampleRate) ReadMiddleFragment(string filePath, CancellationToken ct)
        {
            using var reader = new AudioFileReader(filePath);
            int sampleRate = reader.WaveFormat.SampleRate;
            int channels = reader.WaveFormat.Channels;

            double total = reader.TotalTime.TotalSeconds;
            double start = Math.Max(0, (total - AnalysisSeconds) / 2);
            if (start > 0) reader.CurrentTime = TimeSpan.FromSeconds(start);

            int wanted = (int)(AnalysisSeconds * sampleRate);
            var mono = new float[wanted];
            var buffer = new float[4096 * channels];
            int filled = 0;

            while (filled < wanted)
            {
                ct.ThrowIfCancellationRequested();

                int toRead = Math.Min(buffer.Length, (wanted - filled) * channels);
                int read = reader.Read(buffer, 0, toRead);
                if (read <= 0) break;

                int frames = read / channels;
                for (int f = 0; f < frames; f++)
                {
                    float sum = 0;
                    for (int c = 0; c < channels; c++) sum += buffer[f * channels + c];
                    mono[filled + f] = sum / channels;
                }
                filled += frames;
            }

            if (filled < wanted) Array.Resize(ref mono, filled);
            return (mono, sampleRate);
        }

        // Spectral flux + media local + rectificación + centrado en cero.
        private static double[] ComputeOnsetEnvelope(float[] mono, int sampleRate, CancellationToken ct)
        {
            int frames = (mono.Length - WindowSize) / HopSize + 1;
            int bins = WindowSize / 2;

            var window = new float[WindowSize];
            for (int i = 0; i < WindowSize; i++)
                window[i] = (float)(0.5 - 0.5 * Math.Cos(2 * Math.PI * i / (WindowSize - 1))); // Hann

            var fft = new Complex[WindowSize];
            var previous = new double[bins];
            var flux = new double[frames];

            for (int t = 0; t < frames; t++)
            {
                if ((t & 0xFF) == 0) ct.ThrowIfCancellationRequested();

                int offset = t * HopSize;
                for (int i = 0; i < WindowSize; i++)
                {
                    fft[i].X = mono[offset + i] * window[i];
                    fft[i].Y = 0;
                }
                FastFourierTransform.FFT(true, FftLog2, fft);

                double sum = 0;
                for (int k = 1; k < bins; k++)
                {
                    double mag = Math.Sqrt(fft[k].X * fft[k].X + fft[k].Y * fft[k].Y);
                    double logMag = Math.Log(1 + 1000 * mag);
                    double diff = logMag - previous[k];
                    if (t > 0 && diff > 0) sum += diff;   // solo aumentos de energía
                    previous[k] = logMag;
                }
                flux[t] = sum;
            }

            // Media local con sumas prefijas: env[i] = max(0, flux[i] - media_local[i])
            double frameRate = (double)sampleRate / HopSize;
            int half = Math.Max(1, (int)(LocalMeanSeconds * frameRate));

            var prefix = new double[frames + 1];
            for (int i = 0; i < frames; i++) prefix[i + 1] = prefix[i] + flux[i];

            var env = new double[frames];
            double mean = 0;
            for (int i = 0; i < frames; i++)
            {
                int a = Math.Max(0, i - half);
                int b = Math.Min(frames, i + half + 1);
                double localMean = (prefix[b] - prefix[a]) / (b - a);
                env[i] = Math.Max(0, flux[i] - localMean);
                mean += env[i];
            }

            mean /= frames;
            for (int i = 0; i < frames; i++) env[i] -= mean;
            return env;
        }

        // Autocorrelación + prior de tempo + refinamiento. Devuelve (bpm, confianza 0..1).
        private static (int bpm, double confidence)? PickTempo(double[] env, double frameRate)
        {
            int n = env.Length;
            int minLag = (int)Math.Floor(frameRate * 60 / MaxBpm);
            int maxLag = (int)Math.Ceiling(frameRate * 60 / MinBpm);
            int acMax = Math.Min(n - 1, 4 * maxLag + 3);
            if (acMax < 2 * maxLag + 1) return null;

            var ac = new double[acMax + 1];
            for (int lag = 0; lag <= acMax; lag++)
            {
                double sum = 0;
                for (int i = 0; i + lag < n; i++) sum += env[i] * env[i + lag];
                ac[lag] = sum / (n - lag);
            }
            if (ac[0] <= 1e-9) return null; // silencio o señal plana

            double bestScore = double.MinValue;
            int bestLag = 0;
            double bestPeak = 0;

            for (int lag = minLag; lag <= maxLag; lag++)
            {
                // Máximo entre vecinos: el periodo real casi nunca cae en un lag entero.
                double peak = Math.Max(ac[lag - 1], Math.Max(ac[lag], ac[lag + 1]));
                double score = peak;
                if (2 * lag + 1 <= acMax)
                    score += 0.5 * Math.Max(ac[2 * lag - 1], Math.Max(ac[2 * lag], ac[2 * lag + 1]));

                double bpmCandidate = 60 * frameRate / lag;
                double octaves = Math.Log2(bpmCandidate / PriorCenterBpm);
                score *= Math.Exp(-0.5 * octaves * octaves);   // prior gaussiano en octavas

                if (score > bestScore)
                {
                    bestScore = score;
                    bestLag = lag;
                    bestPeak = peak;
                }
            }

            if (bestLag == 0) return null;

            // Refinamiento: el pico del 4.º múltiplo, dividido entre 4, da 4x más precisión.
            double refinedLag = bestLag;
            int center = 4 * bestLag;
            if (center + 3 <= acMax)
            {
                int bestK = center - 3;
                for (int k = center - 3; k <= center + 3; k++)
                    if (ac[k] > ac[bestK]) bestK = k;

                if (bestK > center - 3 && bestK < center + 3)
                {
                    double y0 = ac[bestK - 1], y1 = ac[bestK], y2 = ac[bestK + 1];
                    double denom = y0 - 2 * y1 + y2;
                    double delta = Math.Abs(denom) > 1e-12 ? 0.5 * (y0 - y2) / denom : 0;
                    refinedLag = (bestK + delta) / 4.0;
                }
            }

            double bpm = 60 * frameRate / refinedLag;
            bpm = Math.Clamp(bpm, MinBpm, MaxBpm);

            // Confianza: correlación normalizada del pico elegido (0 = sin pulso, 1 = periodicidad perfecta).
            double confidence = Math.Clamp(bestPeak / ac[0], 0, 1);
            return ((int)Math.Round(bpm), confidence);
        }
    }
}