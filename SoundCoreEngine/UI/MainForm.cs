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
        private int _contadorId = 1;

        // Se marca en true justo antes de llamar _player.Stop() manualmente,
        // para que Player_PlaybackStopped distinga "el usuario dio Stop/Avanzar"
        // de "la pista terminó sola" — NAudio dispara el mismo evento en ambos casos.
        private bool _stopFueManual;
        private bool _estaPausado;

        public MainForm()
        {
            InitializeComponent();
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

        private Track CrearPistaDesdeFormulario()
        {
            string titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? $"Pista {_contadorId}" : txtTitulo.Text.Trim();
            string artista = string.IsNullOrWhiteSpace(txtArtista.Text) ? "DJ Desconocido" : txtArtista.Text.Trim();
            int bpm = (int)numBpm.Value;
            int duracion = (int)numDuracion.Value;

            return new Track(_contadorId++, titulo, artista, bpm, duracion);
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

        private void btnEncolarFinal_Click(object sender, EventArgs e) =>
            _gestor.EnqueueAtEnd(CrearPistaDesdeFormulario());

        private void btnReproducirSiguiente_Click(object sender, EventArgs e) =>
            _gestor.PlayNext(CrearPistaDesdeFormulario());

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

        // Carga uno o varios archivos de audio, lee sus metadatos con TagLibSharp
        // (con valores por defecto si el tag no trae algo) y encola cada uno al
        // final de la estructura activa. La Track resultante guarda la ruta
        // completa del archivo, que es lo que el reproductor necesita.
        private void btnCargarArchivos_Click(object sender, EventArgs e)
        {
            using var dialogo = new OpenFileDialog
            {
                Filter = "Archivos de audio|*.mp3;*.wav;*.flac;*.m4a;*.wma|Todos los archivos|*.*",
                Multiselect = true,
                Title = "Cargar archivos de audio"
            };

            if (dialogo.ShowDialog(this) != DialogResult.OK) return;

            foreach (var ruta in dialogo.FileNames)
            {
                string nombreArchivo = System.IO.Path.GetFileNameWithoutExtension(ruta);

                string titulo = _lectorMetadatos.ReadTitle(ruta) ?? nombreArchivo;
                string artista = _lectorMetadatos.ReadArtist(ruta) ?? "DJ Desconocido";
                int bpm = _lectorMetadatos.ReadBpm(ruta) ?? 120;
                int duracion = _lectorMetadatos.ReadDurationSeconds(ruta);

                var pista = new Track(_contadorId++, titulo, artista, bpm, duracion, ruta);
                _gestor.EnqueueAtEnd(pista);
            }
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
            dgvCola.Rows.Clear();

            int index = 1;
            int duracionTotal = 0;

            foreach (var p in _gestor.GetActiveQueue())
            {
                dgvCola.Rows.Add(index++, p.Id, $"{p.Title} — {p.Artist}", $"{p.Bpm} BPM", $"{p.Seconds}s");
                duracionTotal += p.Seconds;
            }

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