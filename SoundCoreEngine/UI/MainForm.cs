using System.Collections.Generic;
using System.Linq;
using SoundCoreEngine.Audio;
using SoundCoreEngine.Motor;
using SoundCoreEngine.Models;
using NAudio.Wave;

namespace SoundCoreEngine
{
    public partial class MainForm : Form
    {
        private readonly PlaybackQueueManager _gestor = new();
        private readonly IAudioMetadataProvider _lectorMetadatos = new TagLibReader();
        private readonly NAudioPlayer _player = new();
        private readonly IBpmAnalyzer _analizadorBpm = new SpectralFluxBpmAnalyzer();

        // Por debajo de esta confianza (0..1) el BPM calculado se considera dudoso
        // y, si el archivo trae BPM en sus tags, se usa ese valor como respaldo.
        private const double MinConfianzaBpm = 0.10;
        private string _tituloVentana = "";
        private int _contadorId = 1;

        // Se marca en true justo antes de llamar _player.Stop() manualmente,
        // para que Player_PlaybackStopped distinga "el usuario dio Stop/Avanzar"
        // de "la pista terminó sola" — NAudio dispara el mismo evento en ambos casos.
        private bool _stopFueManual;
        private bool _estaPausado;

        public MainForm()
        {
            InitializeComponent();
            _tituloVentana = Text;
            ConfigurarColumnasGrid();

            _gestor.QueueUpdated += RefrescarVista;
            _player.PlaybackStopped += Player_PlaybackStopped;
            CargarDatosSemilla();
        }

        private void ConfigurarColumnasGrid()
        {
            dgvCola.ColumnCount = 5;
            dgvCola.Columns[0].Name = "Pos";
            dgvCola.Columns[1].Name = "ID";
            dgvCola.Columns[2].Name = "Título / Artista";
            dgvCola.Columns[3].Name = "BPM";
            dgvCola.Columns[4].Name = "Duración";
            dgvCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatosSemilla()
        {
            var demo = new[]
            {
            new Track(_contadorId++, "Strobe", "deadmau5", 128, 634),
            new Track(_contadorId++, "Midnight City", "M83", 105, 243),
            new Track(_contadorId++, "Animals", "Martin Garrix", 130, 304)
        };

            _gestor.LoadSeedData(demo);
        }

        private StructureType LeerEstructuraSeleccionada() =>
            rbPropia.Checked ? StructureType.CustomList :
            rbLinkedList.Checked ? StructureType.LinkedListNative :
            StructureType.ListNative;

        private void RadioEstructura_CheckedChanged(object sender, EventArgs e)
        {
            // Al cambiar de estructura activa, el mismo evento ColaActualizada
            // refresca el grid mostrando la cola equivalente de la nueva estructura.
            _gestor.ActiveStructure = LeerEstructuraSeleccionada();
            RefrescarVista();
        }

        // Encolar al final: permite varios archivos, se agregan en el orden elegido.
        private async void btnEncolarFinal_Click(object sender, EventArgs e)
        {
            foreach (var pista in await SeleccionarPistasAsync(true, "Encolar al final"))
                _gestor.EnqueueAtEnd(pista);
        }

        // Reproducir siguiente: un solo archivo, porque PlayNext inserta justo después
        // de la cabeza y varios archivos quedarían en orden inverso.
        private async void btnReproducirSiguiente_Click(object sender, EventArgs e)
        {
            var pista = (await SeleccionarPistasAsync(false, "Reproducir siguiente")).FirstOrDefault();
            if (pista != null)
                _gestor.PlayNext(pista);
        }

        // Avance manual: corta lo que esté sonando, saca la cabeza actual y
        // reproduce automáticamente lo que quede al frente. Se marca como
        // stop manual para que Player_PlaybackStopped no vuelva a avanzar por su cuenta.
        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            _stopFueManual = true;
            _player.Stop();
            playbackTimer.Stop();

            try
            {
                _gestor.AdvanceTrack();
                ReproducirCabeza();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No hay pistas pendientes en la cola.", "Fin del Setlist",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInvertir_Click(object sender, EventArgs e) => _gestor.Invert();

        private void btnOrdenarBpm_Click(object sender, EventArgs e) => _gestor.OrderByBpm();

        private void btnPurgar_Click(object sender, EventArgs e) => _gestor.PurgeDuplicatesByTitle();

        // Abre el diálogo de archivos y devuelve las pistas ya construidas: título y
        // artista desde TagLib, BPM calculado por análisis de señal (ver ResolverBpmAsync)
        // y ruta completa. Lista vacía si el usuario cancela.
        private async Task<List<Track>> SeleccionarPistasAsync(bool multiple, string titulo)
        {
            using var dialogo = new OpenFileDialog
            {
                Filter = "Archivos de audio|*.mp3;*.wav;*.flac;*.m4a;*.wma|Todos los archivos|*.*",
                Multiselect = multiple,
                Title = titulo
            };

            var pistas = new List<Track>();
            if (dialogo.ShowDialog(this) != DialogResult.OK) return pistas;

            var rutas = dialogo.FileNames;
            EstablecerAnalizando(true);
            try
            {
                for (int i = 0; i < rutas.Length; i++)
                {
                    Text = $"{_tituloVentana} — Analizando BPM ({i + 1}/{rutas.Length})...";

                    string ruta = rutas[i];
                    string nombreArchivo = System.IO.Path.GetFileNameWithoutExtension(ruta);

                    string tituloPista = _lectorMetadatos.ReadTitle(ruta) ?? nombreArchivo;
                    string artista = _lectorMetadatos.ReadArtist(ruta) ?? "DJ Desconocido";
                    int duracion = _lectorMetadatos.ReadDurationSeconds(ruta);
                    int bpm = await ResolverBpmAsync(ruta);

                    pistas.Add(new Track(_contadorId++, tituloPista, artista, bpm, duracion, ruta));
                }
            }
            finally
            {
                EstablecerAnalizando(false);
            }
            return pistas;
        }

        // El BPM se calcula siempre a partir del audio. El tag solo es respaldo:
        // se usa si el análisis falla o su confianza es baja. Último recurso: 120.
        private async Task<int> ResolverBpmAsync(string ruta)
        {
            int? bpmTag = _lectorMetadatos.ReadBpm(ruta);

            (int bpm, double confidence)? estimado = null;
            try
            {
                estimado = await _analizadorBpm.EstimateBpmAsync(ruta);
            }
            catch (Exception)
            {
                // Se ignora: se cae al tag o al valor por defecto.
            }

            if (estimado is { } e && (e.confidence >= MinConfianzaBpm || bpmTag == null))
                return e.bpm;

            return bpmTag ?? 120;
        }

        // Evita acciones reentrantes mientras se analiza el audio en segundo plano.
        private void EstablecerAnalizando(bool analizando)
        {
            btnEncolarFinal.Enabled = !analizando;
            btnReproducirSiguiente.Enabled = !analizando;
            btnCargarArchivos.Enabled = !analizando;
            Cursor = analizando ? Cursors.WaitCursor : Cursors.Default;
            if (!analizando) Text = _tituloVentana;
        }

        // "Cargar Archivos" comparte la misma lógica que Encolar al Final.
        private async void btnCargarArchivos_Click(object sender, EventArgs e)
        {
            foreach (var pista in await SeleccionarPistasAsync(true, "Cargar archivos de audio"))
                _gestor.EnqueueAtEnd(pista);
        }

        private const int TotalSimulacion = 25_000;

        // Simulación de carga masiva: lee canciones desde un .txt y encola 25,000
        // pistas SIN archivo de audio (FilePath vacío). Formato por línea:
        //     Título;Artista;BPM;Duración(segundos)
        // Las líneas vacías, las que empiezan con '#' y las inválidas se ignoran.
        // Si el archivo trae menos de 25,000 líneas válidas, se reciclan en ciclo
        // hasta completar la cantidad (cada pista recibe un Id nuevo).
        private void btnSimular_Click(object sender, EventArgs e)
        {
            using var dialogo = new OpenFileDialog
            {
                Filter = "Archivos de texto|*.txt|Todos los archivos|*.*",
                Title = "Seleccionar archivo con datos de canciones"
            };
            if (dialogo.ShowDialog(this) != DialogResult.OK) return;

            var plantillas = LeerPlantillasDesdeTxt(dialogo.FileName);
            if (plantillas.Count == 0)
            {
                MessageBox.Show(
                    "El archivo no contiene líneas válidas.\r\nFormato esperado por línea:\r\nTítulo;Artista;BPM;Duración(segundos)",
                    "Archivo sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pistas = new List<Track>(TotalSimulacion);
            for (int i = 0; i < TotalSimulacion; i++)
            {
                var d = plantillas[i % plantillas.Count];
                pistas.Add(new Track(_contadorId++, d.Titulo, d.Artista, d.Bpm, d.Segundos));
            }

            // Se desuscribe el refresco del grid: de lo contrario se redibujaría
            // 25,000 veces (una por inserción). Se refresca una sola vez al final.
            Cursor = Cursors.WaitCursor;
            btnSimular.Enabled = false;
            var cronometro = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                _gestor.QueueUpdated -= RefrescarVista;
                foreach (var pista in pistas)
                    _gestor.EnqueueAtEnd(pista);
                cronometro.Stop();
            }
            finally
            {
                _gestor.QueueUpdated += RefrescarVista;
                RefrescarVista();
                btnSimular.Enabled = true;
                Cursor = Cursors.Default;
            }

            MessageBox.Show(
                $"Se insertaron {TotalSimulacion:N0} pistas sin archivo de audio.\r\n" +
                $"Tiempo de inserción: {cronometro.ElapsedMilliseconds} ms",
                "Simulación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static List<(string Titulo, string Artista, int Bpm, int Segundos)> LeerPlantillasDesdeTxt(string ruta)
        {
            var lista = new List<(string, string, int, int)>();

            foreach (var linea in System.IO.File.ReadLines(ruta))
            {
                var texto = linea.Trim();
                if (texto.Length == 0 || texto.StartsWith('#')) continue;

                var partes = texto.Split(';');
                if (partes.Length < 4) partes = texto.Split(',');
                if (partes.Length < 4) continue;

                if (!int.TryParse(partes[^2].Trim(), out int bpm) || bpm <= 0) continue;
                if (!int.TryParse(partes[^1].Trim(), out int seg) || seg < 0) continue;

                // Si el título trae separadores de más, el penúltimo-1 es el artista.
                string artista = partes[^3].Trim();
                string titulo = string.Join(" ", partes.Take(partes.Length - 3)).Trim();
                if (titulo.Length == 0) continue;

                lista.Add((titulo, artista.Length == 0 ? "DJ Desconocido" : artista, bpm, seg));
            }
            return lista;
        }

        // Play siempre actúa sobre la cabeza de la cola activa (no sobre la
        // fila seleccionada del grid), tal como se acordó.
        private void btnPlay_Click(object sender, EventArgs e) => ReproducirCabeza();

        private void ReproducirCabeza()
        {
            var cabeza = _gestor.GetActiveQueue().FirstOrDefault();
            if (cabeza == null)
            {
                lblNowPlaying.Text = "▶ Sonando: (la cola está vacía)";
                lblNowPlaying.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
                return;
            }

            if (string.IsNullOrWhiteSpace(cabeza.FilePath))
            {
                MessageBox.Show(
                    $"\"{cabeza.Title}\" no tiene un archivo de audio asociado (se agregó manualmente sin archivo). " +
                    "Usa \"Cargar Archivos\" para encolar una pista con audio real.",
                    "Sin archivo de audio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _stopFueManual = false;
            _player.Play(cabeza.FilePath);
            playbackTimer.Start();

            lblNowPlaying.Text = $"▶ Sonando: {cabeza.Title} - {cabeza.Artist} ({cabeza.Bpm} BPM)";
            lblNowPlaying.ForeColor = Color.FromArgb(0x3F, 0xD0, 0xC9);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!_player.IsPlaying && !_estaPausado) return;

            if (_estaPausado)
            {
                _player.Resume();
                playbackTimer.Start();
                btnPause.Text = "⏸ Pausar";
                _estaPausado = false;
            }
            else
            {
                _player.Pause();
                playbackTimer.Stop();
                btnPause.Text = "▶ Reanudar";
                _estaPausado = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stopFueManual = true;
            _estaPausado = false;
            btnPause.Text = "⏸ Pausar";

            _player.Stop();
            playbackTimer.Stop();

            progressBarPlayback.Value = 0;
            lblTiempoTranscurrido.Text = "00:00 / 00:00";
        }

        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            var actual = _player.CurrentPosition;
            var total = _player.TotalDuration;

            if (total.TotalSeconds > 0)
            {
                progressBarPlayback.Value = Math.Clamp(
                    (int)(actual.TotalSeconds / total.TotalSeconds * progressBarPlayback.Maximum),
                    0, progressBarPlayback.Maximum);
            }

            lblTiempoTranscurrido.Text = $"{actual:mm\\:ss} / {total:mm\\:ss}";
        }

        // Se dispara en un hilo de fondo de NAudio — hay que regresar al hilo
        // de UI antes de tocar cualquier control. Distingue "el usuario dio
        // Stop/Avanzar" (no hacer nada más) de "la pista terminó sola"
        // (auto-avanzar y seguir reproduciendo).
        private void Player_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Player_PlaybackStopped(sender, e)));
                return;
            }

            playbackTimer.Stop();

            if (_stopFueManual)
            {
                _stopFueManual = false;
                return;
            }

            try
            {
                _gestor.AdvanceTrack();
                ReproducirCabeza();
            }
            catch (InvalidOperationException)
            {
                lblNowPlaying.Text = "▶ Sonando: (setlist terminado)";
                lblNowPlaying.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
                progressBarPlayback.Value = 0;
                lblTiempoTranscurrido.Text = "00:00 / 00:00";
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _player.Dispose();
            base.OnFormClosed(e);
        }

        private void RefrescarVista()
        {
            dgvCola.SuspendLayout();
            dgvCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCola.Rows.Clear();

            int index = 1;
            int duracionTotal = 0;

            foreach (var p in _gestor.GetActiveQueue())
            {
                dgvCola.Rows.Add(index++, p.Id, $"{p.Title} — {p.Artist}", $"{p.Bpm} BPM", $"{p.Seconds}s");
                duracionTotal += p.Seconds;
            }

            dgvCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCola.ResumeLayout();

            lblEstadisticas.Text = $"Total en cola: {index - 1} | Tiempo total: {TimeSpan.FromSeconds(duracionTotal):mm\\:ss}";
        }

        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            int n = (int)numInseccionesBenchmark.Value;
            var servicio = new SoundCoreEngine.Motor.BenchmarkService();
            var resultado = servicio.Execute(n);

            txtResultadosBenchmark.Text =
                $"=== RESULTADOS DE ESTRÉS ({resultado.Insertions:N0} INSERCIONES INTERMEDIAS) ===\r\n" +
                $"• Lista Enlazada Propia (Nodos):  {resultado.MillisecondsCustomList} ms  [O(1) por reconexión]\r\n" +
                $"• .NET LinkedList<T>:             {resultado.MillisecondsLinkedList} ms  [O(1) nativa]\r\n" +
                $"• .NET List<T> (Arreglo Dinámico): {resultado.MillisecondsList} ms  [O(n) por Array.Copy]\r\n\r\n" +
                $"Conclusión Técnica: {resultado.Conclusion}";
        }
    }
}