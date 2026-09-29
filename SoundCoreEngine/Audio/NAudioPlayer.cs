using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCoreEngine.Audio
{
    public class NAudioPlayer : IDisposable
    {
        private WaveOutEvent? _output;
        private AudioFileReader? _reader;

        public bool IsPlaying => _output?.PlaybackState == PlaybackState.Playing;
        public bool IsPaused => _output?.PlaybackState == PlaybackState.Paused;

        public TimeSpan CurrentPosition => _reader?.CurrentTime ?? TimeSpan.Zero;
        public TimeSpan TotalDuration => _reader?.TotalTime ?? TimeSpan.Zero;

        /// <summary>
        /// Reenvía el evento nativo PlaybackStopped de NAudio tal cual. Se dispara
        /// tanto cuando una pista termina sola como cuando se llama Stop()
        /// manualmente — quien se suscriba decide cómo distinguir los dos casos.
        /// Ojo: se dispara en un hilo de fondo, no en el hilo de UI; hay que
        /// hacer Invoke antes de tocar cualquier control del Form.
        /// </summary>
        public event EventHandler<StoppedEventArgs>? PlaybackStopped;

        public void Play(string filePath)
        {
            Stop();

            _reader = new AudioFileReader(filePath);
            _output = new WaveOutEvent();
            _output.Init(_reader);
            _output.PlaybackStopped += (sender, args) => PlaybackStopped?.Invoke(sender, args);
            _output.Play();
        }

        public void Pause() => _output?.Pause();

        public void Resume() => _output?.Play();

        public void Stop()
        {
            _output?.Stop();
            _output?.Dispose();
            _reader?.Dispose();
            _output = null;
            _reader = null;
        }

        public void Dispose() => Stop();
    }
}