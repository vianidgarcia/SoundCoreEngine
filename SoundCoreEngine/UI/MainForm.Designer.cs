namespace SoundCoreEngine
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelRegistro = new FlowLayoutPanel();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblArtista = new Label();
            txtArtista = new TextBox();
            lblBpm = new Label();
            numBpm = new NumericUpDown();
            lblDuracion = new Label();
            numDuracion = new NumericUpDown();
            rbPropia = new RadioButton();
            rbLinkedList = new RadioButton();
            rbList = new RadioButton();
            btnCargarArchivos = new Button();
            panelAcciones = new FlowLayoutPanel();
            btnEncolarFinal = new Button();
            btnReproducirSiguiente = new Button();
            btnAvanzar = new Button();
            btnInvertir = new Button();
            btnOrdenarBpm = new Button();
            btnPurgar = new Button();
            panelPlaylist = new Panel();
            dgvCola = new DataGridView();
            lblNowPlaying = new Label();
            panelTransporte = new FlowLayoutPanel();
            btnPlay = new Button();
            btnPause = new Button();
            btnStop = new Button();
            progressBarPlayback = new ProgressBar();
            lblTiempoTranscurrido = new Label();
            lblEstadisticas = new Label();
            playbackTimer = new System.Windows.Forms.Timer(components);
            panelBenchmark = new TableLayoutPanel();
            lblBenchmark = new Label();
            numInseccionesBenchmark = new NumericUpDown();
            txtResultadosBenchmark = new TextBox();
            btnBenchmark = new Button();
            panelRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            panelAcciones.SuspendLayout();
            panelPlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCola).BeginInit();
            panelTransporte.SuspendLayout();
            panelBenchmark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numInseccionesBenchmark).BeginInit();
            SuspendLayout();
            // 
            // panelRegistro
            // 
            panelRegistro.Controls.Add(lblTitulo);
            panelRegistro.Controls.Add(txtTitulo);
            panelRegistro.Controls.Add(lblArtista);
            panelRegistro.Controls.Add(txtArtista);
            panelRegistro.Controls.Add(lblBpm);
            panelRegistro.Controls.Add(numBpm);
            panelRegistro.Controls.Add(lblDuracion);
            panelRegistro.Controls.Add(numDuracion);
            panelRegistro.Controls.Add(rbPropia);
            panelRegistro.Controls.Add(rbLinkedList);
            panelRegistro.Controls.Add(rbList);
            panelRegistro.Controls.Add(btnCargarArchivos);
            panelRegistro.Dock = DockStyle.Top;
            panelRegistro.Location = new Point(0, 0);
            panelRegistro.Name = "panelRegistro";
            panelRegistro.Padding = new Padding(10);
            panelRegistro.Size = new Size(1100, 100);
            panelRegistro.TabIndex = 0;
            panelRegistro.BackColor = Color.FromArgb(0x22, 0x27, 0x2E);
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(13, 18);
            lblTitulo.Margin = new Padding(3, 8, 3, 3);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(40, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            lblTitulo.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(59, 13);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(160, 23);
            txtTitulo.TabIndex = 1;
            txtTitulo.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            txtTitulo.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            txtTitulo.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblArtista
            // 
            lblArtista.AutoSize = true;
            lblArtista.Location = new Point(232, 18);
            lblArtista.Margin = new Padding(10, 8, 3, 3);
            lblArtista.Name = "lblArtista";
            lblArtista.Size = new Size(44, 15);
            lblArtista.TabIndex = 2;
            lblArtista.Text = "Artista:";
            lblArtista.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // txtArtista
            // 
            txtArtista.Location = new Point(282, 13);
            txtArtista.Name = "txtArtista";
            txtArtista.Size = new Size(160, 23);
            txtArtista.TabIndex = 3;
            txtArtista.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            txtArtista.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            txtArtista.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblBpm
            // 
            lblBpm.AutoSize = true;
            lblBpm.Location = new Point(455, 18);
            lblBpm.Margin = new Padding(10, 8, 3, 3);
            lblBpm.Name = "lblBpm";
            lblBpm.Size = new Size(35, 15);
            lblBpm.TabIndex = 4;
            lblBpm.Text = "BPM:";
            lblBpm.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // numBpm
            // 
            numBpm.Location = new Point(496, 13);
            numBpm.Maximum = new decimal(new int[] { 220, 0, 0, 0 });
            numBpm.Minimum = new decimal(new int[] { 60, 0, 0, 0 });
            numBpm.Name = "numBpm";
            numBpm.Size = new Size(60, 23);
            numBpm.TabIndex = 5;
            numBpm.Value = new decimal(new int[] { 124, 0, 0, 0 });
            numBpm.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            numBpm.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            numBpm.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(569, 18);
            lblDuracion.Margin = new Padding(10, 8, 3, 3);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(71, 15);
            lblDuracion.TabIndex = 6;
            lblDuracion.Text = "Duración(s):";
            lblDuracion.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // numDuracion
            // 
            numDuracion.Location = new Point(646, 13);
            numDuracion.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(70, 23);
            numDuracion.TabIndex = 7;
            numDuracion.Value = new decimal(new int[] { 210, 0, 0, 0 });
            numDuracion.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            numDuracion.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            numDuracion.BorderStyle = BorderStyle.FixedSingle;
            // 
            // rbPropia
            // 
            rbPropia.AutoSize = true;
            rbPropia.Checked = true;
            rbPropia.Location = new Point(739, 18);
            rbPropia.Margin = new Padding(20, 8, 3, 3);
            rbPropia.Name = "rbPropia";
            rbPropia.Size = new Size(171, 19);
            rbPropia.TabIndex = 8;
            rbPropia.TabStop = true;
            rbPropia.Text = "Lista Simple Propia (Nodos)";
            rbPropia.UseVisualStyleBackColor = true;
            rbPropia.CheckedChanged += RadioEstructura_CheckedChanged;
            rbPropia.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // rbLinkedList
            // 
            rbLinkedList.AutoSize = true;
            rbLinkedList.Location = new Point(923, 18);
            rbLinkedList.Margin = new Padding(10, 8, 3, 3);
            rbLinkedList.Name = "rbLinkedList";
            rbLinkedList.Size = new Size(127, 19);
            rbLinkedList.TabIndex = 9;
            rbLinkedList.Text = ".NET LinkedList<T>";
            rbLinkedList.UseVisualStyleBackColor = true;
            rbLinkedList.CheckedChanged += RadioEstructura_CheckedChanged;
            rbLinkedList.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // rbList
            // 
            rbList.AutoSize = true;
            rbList.Location = new Point(20, 48);
            rbList.Margin = new Padding(10, 8, 3, 3);
            rbList.Name = "rbList";
            rbList.Size = new Size(92, 19);
            rbList.TabIndex = 10;
            rbList.Text = ".NET List<T>";
            rbList.UseVisualStyleBackColor = true;
            rbList.CheckedChanged += RadioEstructura_CheckedChanged;
            rbList.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // btnCargarArchivos
            // 
            btnCargarArchivos.AutoSize = true;
            btnCargarArchivos.Location = new Point(130, 45);
            btnCargarArchivos.Margin = new Padding(15, 5, 3, 3);
            btnCargarArchivos.Name = "btnCargarArchivos";
            btnCargarArchivos.Size = new Size(130, 27);
            btnCargarArchivos.TabIndex = 11;
            btnCargarArchivos.Text = "📁 Cargar Archivos...";
            btnCargarArchivos.UseVisualStyleBackColor = true;
            btnCargarArchivos.Click += btnCargarArchivos_Click;
            btnCargarArchivos.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnCargarArchivos.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnCargarArchivos.FlatStyle = FlatStyle.Flat;
            btnCargarArchivos.FlatAppearance.BorderSize = 0;
            // 
            // panelAcciones
            // 
            panelAcciones.Controls.Add(btnEncolarFinal);
            panelAcciones.Controls.Add(btnReproducirSiguiente);
            panelAcciones.Controls.Add(btnAvanzar);
            panelAcciones.Controls.Add(btnInvertir);
            panelAcciones.Controls.Add(btnOrdenarBpm);
            panelAcciones.Controls.Add(btnPurgar);
            panelAcciones.Dock = DockStyle.Left;
            panelAcciones.FlowDirection = FlowDirection.TopDown;
            panelAcciones.Location = new Point(0, 100);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Padding = new Padding(10);
            panelAcciones.Size = new Size(220, 469);
            panelAcciones.TabIndex = 1;
            panelAcciones.WrapContents = false;
            panelAcciones.BackColor = Color.FromArgb(0x22, 0x27, 0x2E);
            // 
            // btnEncolarFinal
            // 
            btnEncolarFinal.Location = new Point(13, 13);
            btnEncolarFinal.Name = "btnEncolarFinal";
            btnEncolarFinal.Size = new Size(190, 32);
            btnEncolarFinal.TabIndex = 0;
            btnEncolarFinal.Text = "+ Encolar al Final";
            btnEncolarFinal.UseVisualStyleBackColor = true;
            btnEncolarFinal.Click += btnEncolarFinal_Click;
            btnEncolarFinal.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnEncolarFinal.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnEncolarFinal.FlatStyle = FlatStyle.Flat;
            btnEncolarFinal.FlatAppearance.BorderSize = 0;
            // 
            // btnReproducirSiguiente
            // 
            btnReproducirSiguiente.Location = new Point(13, 51);
            btnReproducirSiguiente.Name = "btnReproducirSiguiente";
            btnReproducirSiguiente.Size = new Size(190, 32);
            btnReproducirSiguiente.TabIndex = 1;
            btnReproducirSiguiente.Text = "⏭ Reproducir Siguiente";
            btnReproducirSiguiente.UseVisualStyleBackColor = true;
            btnReproducirSiguiente.Click += btnReproducirSiguiente_Click;
            btnReproducirSiguiente.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnReproducirSiguiente.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnReproducirSiguiente.FlatStyle = FlatStyle.Flat;
            btnReproducirSiguiente.FlatAppearance.BorderSize = 0;
            // 
            // btnAvanzar
            // 
            btnAvanzar.Location = new Point(13, 89);
            btnAvanzar.Name = "btnAvanzar";
            btnAvanzar.Size = new Size(190, 32);
            btnAvanzar.TabIndex = 2;
            btnAvanzar.Text = "⏩ Avanzar Pista";
            btnAvanzar.UseVisualStyleBackColor = true;
            btnAvanzar.Click += btnAvanzar_Click;
            btnAvanzar.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnAvanzar.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnAvanzar.FlatStyle = FlatStyle.Flat;
            btnAvanzar.FlatAppearance.BorderSize = 0;
            // 
            // btnInvertir
            // 
            btnInvertir.Location = new Point(13, 127);
            btnInvertir.Name = "btnInvertir";
            btnInvertir.Size = new Size(190, 32);
            btnInvertir.TabIndex = 3;
            btnInvertir.Text = "⇅ Invertir Lista (In-Place)";
            btnInvertir.UseVisualStyleBackColor = true;
            btnInvertir.Click += btnInvertir_Click;
            btnInvertir.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnInvertir.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnInvertir.FlatStyle = FlatStyle.Flat;
            btnInvertir.FlatAppearance.BorderSize = 0;
            // 
            // btnOrdenarBpm
            // 
            btnOrdenarBpm.Location = new Point(13, 165);
            btnOrdenarBpm.Name = "btnOrdenarBpm";
            btnOrdenarBpm.Size = new Size(190, 32);
            btnOrdenarBpm.TabIndex = 4;
            btnOrdenarBpm.Text = "⚡ Ordenar por Curva BPM";
            btnOrdenarBpm.UseVisualStyleBackColor = true;
            btnOrdenarBpm.Click += btnOrdenarBpm_Click;
            btnOrdenarBpm.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnOrdenarBpm.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnOrdenarBpm.FlatStyle = FlatStyle.Flat;
            btnOrdenarBpm.FlatAppearance.BorderSize = 0;
            // 
            // btnPurgar
            // 
            btnPurgar.Location = new Point(13, 203);
            btnPurgar.Name = "btnPurgar";
            btnPurgar.Size = new Size(190, 32);
            btnPurgar.TabIndex = 5;
            btnPurgar.Text = "\U0001f9f9 Purgar Duplicados";
            btnPurgar.UseVisualStyleBackColor = true;
            btnPurgar.Click += btnPurgar_Click;
            btnPurgar.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnPurgar.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnPurgar.FlatStyle = FlatStyle.Flat;
            btnPurgar.FlatAppearance.BorderSize = 0;
            // 
            // panelPlaylist
            // 
            panelPlaylist.Controls.Add(dgvCola);
            panelPlaylist.Controls.Add(lblNowPlaying);
            panelPlaylist.Controls.Add(panelTransporte);
            panelPlaylist.Controls.Add(lblEstadisticas);
            panelPlaylist.Dock = DockStyle.Fill;
            panelPlaylist.Location = new Point(220, 100);
            panelPlaylist.Name = "panelPlaylist";
            panelPlaylist.Size = new Size(880, 469);
            panelPlaylist.TabIndex = 2;
            panelPlaylist.BackColor = Color.FromArgb(0x22, 0x27, 0x2E);
            // 
            // dgvCola
            // 
            dgvCola.AllowUserToAddRows = false;
            dgvCola.AllowUserToDeleteRows = false;
            dgvCola.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCola.Location = new Point(0, 70);
            dgvCola.Name = "dgvCola";
            dgvCola.ReadOnly = true;
            dgvCola.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCola.Size = new Size(880, 375);
            dgvCola.TabIndex = 0;
            dgvCola.BackgroundColor = Color.FromArgb(0x22, 0x27, 0x2E);
            dgvCola.BorderStyle = BorderStyle.None;
            dgvCola.GridColor = Color.FromArgb(0x3A, 0x41, 0x4B);
            dgvCola.EnableHeadersVisualStyles = false;
            dgvCola.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            dgvCola.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            dgvCola.DefaultCellStyle.BackColor = Color.FromArgb(0x22, 0x27, 0x2E);
            dgvCola.DefaultCellStyle.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            dgvCola.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            dgvCola.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0x3F, 0xD0, 0xC9);
            // 
            // lblNowPlaying
            // 
            lblNowPlaying.Dock = DockStyle.Top;
            lblNowPlaying.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNowPlaying.Location = new Point(0, 0);
            lblNowPlaying.Name = "lblNowPlaying";
            lblNowPlaying.Size = new Size(880, 30);
            lblNowPlaying.TabIndex = 1;
            lblNowPlaying.Text = "▶ Sonando: (nada en reproducción)";
            lblNowPlaying.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // panelTransporte
            // 
            panelTransporte.Controls.Add(btnPlay);
            panelTransporte.Controls.Add(btnPause);
            panelTransporte.Controls.Add(btnStop);
            panelTransporte.Controls.Add(progressBarPlayback);
            panelTransporte.Controls.Add(lblTiempoTranscurrido);
            panelTransporte.Location = new Point(0, 30);
            panelTransporte.Name = "panelTransporte";
            panelTransporte.Padding = new Padding(0, 3, 0, 3);
            panelTransporte.Size = new Size(880, 40);
            panelTransporte.TabIndex = 4;
            panelTransporte.BackColor = Color.FromArgb(0x22, 0x27, 0x2E);
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(3, 6);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(100, 28);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "▶ Play (Head)";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            btnPlay.BackColor = Color.FromArgb(0x3F, 0xD0, 0xC9);
            btnPlay.ForeColor = Color.FromArgb(0x0D, 0x1B, 0x1A);
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.FlatAppearance.BorderSize = 0;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(109, 6);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(90, 28);
            btnPause.TabIndex = 1;
            btnPause.Text = "⏸ Pausar";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            btnPause.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnPause.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.FlatAppearance.BorderSize = 0;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(205, 6);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(80, 28);
            btnStop.TabIndex = 2;
            btnStop.Text = "⏹ Detener";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            btnStop.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            btnStop.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.FlatAppearance.BorderSize = 0;
            // 
            // progressBarPlayback
            // 
            progressBarPlayback.Location = new Point(291, 6);
            progressBarPlayback.Maximum = 1000;
            progressBarPlayback.Name = "progressBarPlayback";
            progressBarPlayback.Size = new Size(300, 22);
            progressBarPlayback.TabIndex = 3;
            progressBarPlayback.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            // 
            // lblTiempoTranscurrido
            // 
            lblTiempoTranscurrido.AutoSize = true;
            lblTiempoTranscurrido.Location = new Point(597, 3);
            lblTiempoTranscurrido.Name = "lblTiempoTranscurrido";
            lblTiempoTranscurrido.Size = new Size(72, 15);
            lblTiempoTranscurrido.TabIndex = 4;
            lblTiempoTranscurrido.Text = "00:00 / 00:00";
            lblTiempoTranscurrido.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // lblEstadisticas
            // 
            lblEstadisticas.Dock = DockStyle.Bottom;
            lblEstadisticas.Location = new Point(0, 445);
            lblEstadisticas.Name = "lblEstadisticas";
            lblEstadisticas.Size = new Size(880, 24);
            lblEstadisticas.TabIndex = 2;
            lblEstadisticas.Text = "Total en cola: 0";
            lblEstadisticas.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // playbackTimer
            // 
            playbackTimer.Interval = 300;
            playbackTimer.Tick += PlaybackTimer_Tick;
            // 
            // panelBenchmark
            // 
            panelBenchmark.ColumnCount = 3;
            panelBenchmark.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 113F));
            panelBenchmark.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            panelBenchmark.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            panelBenchmark.Controls.Add(lblBenchmark, 0, 0);
            panelBenchmark.Controls.Add(txtResultadosBenchmark, 0, 1);
            panelBenchmark.Controls.Add(btnBenchmark, 2, 0);
            panelBenchmark.Controls.Add(numInseccionesBenchmark, 1, 0);
            panelBenchmark.Dock = DockStyle.Bottom;
            panelBenchmark.Location = new Point(0, 569);
            panelBenchmark.Name = "panelBenchmark";
            panelBenchmark.Padding = new Padding(10);
            panelBenchmark.RowCount = 2;
            panelBenchmark.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            panelBenchmark.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelBenchmark.Size = new Size(1100, 180);
            panelBenchmark.TabIndex = 3;
            panelBenchmark.BackColor = Color.FromArgb(0x22, 0x27, 0x2E);
            // 
            // lblBenchmark
            // 
            lblBenchmark.Anchor = AnchorStyles.Left;
            lblBenchmark.Location = new Point(13, 10);
            lblBenchmark.Name = "lblBenchmark";
            lblBenchmark.Size = new Size(107, 40);
            lblBenchmark.TabIndex = 0;
            lblBenchmark.Text = "Cantidad de pistas para test de estrés:";
            lblBenchmark.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            // 
            // numInseccionesBenchmark
            // 
            numInseccionesBenchmark.Anchor = AnchorStyles.Left;
            numInseccionesBenchmark.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numInseccionesBenchmark.Location = new Point(126, 18);
            numInseccionesBenchmark.Maximum = new decimal(new int[] { 200000, 0, 0, 0 });
            numInseccionesBenchmark.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numInseccionesBenchmark.Name = "numInseccionesBenchmark";
            numInseccionesBenchmark.Size = new Size(55, 23);
            numInseccionesBenchmark.TabIndex = 1;
            numInseccionesBenchmark.Value = new decimal(new int[] { 20000, 0, 0, 0 });
            numInseccionesBenchmark.BackColor = Color.FromArgb(0x2D, 0x33, 0x3B);
            numInseccionesBenchmark.ForeColor = Color.FromArgb(0xD8, 0xDD, 0xE3);
            numInseccionesBenchmark.BorderStyle = BorderStyle.FixedSingle;
            // 
            // txtResultadosBenchmark
            // 
            panelBenchmark.SetColumnSpan(txtResultadosBenchmark, 3);
            txtResultadosBenchmark.Dock = DockStyle.Fill;
            txtResultadosBenchmark.Font = new Font("Consolas", 9F);
            txtResultadosBenchmark.Location = new Point(13, 53);
            txtResultadosBenchmark.Multiline = true;
            txtResultadosBenchmark.Name = "txtResultadosBenchmark";
            txtResultadosBenchmark.ReadOnly = true;
            txtResultadosBenchmark.ScrollBars = ScrollBars.Vertical;
            txtResultadosBenchmark.Size = new Size(1074, 114);
            txtResultadosBenchmark.TabIndex = 3;
            txtResultadosBenchmark.BackColor = Color.FromArgb(0x14, 0x18, 0x1C);
            txtResultadosBenchmark.ForeColor = Color.FromArgb(0x8B, 0x95, 0xA1);
            txtResultadosBenchmark.BorderStyle = BorderStyle.FixedSingle;
            // 
            // btnBenchmark
            // 
            btnBenchmark.AutoSize = true;
            btnBenchmark.Location = new Point(188, 13);
            btnBenchmark.Name = "btnBenchmark";
            btnBenchmark.Size = new Size(191, 25);
            btnBenchmark.TabIndex = 2;
            btnBenchmark.Text = "🚀 Iniciar Prueba de Rendimiento";
            btnBenchmark.UseVisualStyleBackColor = true;
            btnBenchmark.Click += btnBenchmark_Click;
            btnBenchmark.BackColor = Color.FromArgb(0x3F, 0xD0, 0xC9);
            btnBenchmark.ForeColor = Color.FromArgb(0x0D, 0x1B, 0x1A);
            btnBenchmark.FlatStyle = FlatStyle.Flat;
            btnBenchmark.FlatAppearance.BorderSize = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 749);
            Controls.Add(panelPlaylist);
            Controls.Add(panelAcciones);
            Controls.Add(panelBenchmark);
            Controls.Add(panelRegistro);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";
            BackColor = Color.FromArgb(0x1B, 0x1F, 0x24);
            panelRegistro.ResumeLayout(false);
            panelRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBpm).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            panelAcciones.ResumeLayout(false);
            panelPlaylist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCola).EndInit();
            panelTransporte.ResumeLayout(false);
            panelTransporte.PerformLayout();
            panelBenchmark.ResumeLayout(false);
            panelBenchmark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numInseccionesBenchmark).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // Declaración de controles accesibles para el diseñador
        private System.Windows.Forms.FlowLayoutPanel panelRegistro;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblArtista;
        private System.Windows.Forms.TextBox txtArtista;
        private System.Windows.Forms.Label lblBpm;
        private System.Windows.Forms.NumericUpDown numBpm;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.NumericUpDown numDuracion;
        private System.Windows.Forms.RadioButton rbPropia;
        private System.Windows.Forms.RadioButton rbLinkedList;
        private System.Windows.Forms.RadioButton rbList;
        private System.Windows.Forms.Button btnCargarArchivos;

        private System.Windows.Forms.FlowLayoutPanel panelAcciones;
        private System.Windows.Forms.Button btnEncolarFinal;
        private System.Windows.Forms.Button btnReproducirSiguiente;
        private System.Windows.Forms.Button btnAvanzar;
        private System.Windows.Forms.Button btnInvertir;
        private System.Windows.Forms.Button btnOrdenarBpm;
        private System.Windows.Forms.Button btnPurgar;

        private System.Windows.Forms.Panel panelPlaylist;
        private System.Windows.Forms.DataGridView dgvCola;
        private System.Windows.Forms.Label lblNowPlaying;
        private System.Windows.Forms.FlowLayoutPanel panelTransporte;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar progressBarPlayback;
        private System.Windows.Forms.Label lblTiempoTranscurrido;
        private System.Windows.Forms.Label lblEstadisticas;
        private System.Windows.Forms.Timer playbackTimer;

        private System.Windows.Forms.TableLayoutPanel panelBenchmark;
        private System.Windows.Forms.Label lblBenchmark;
        private System.Windows.Forms.NumericUpDown numInseccionesBenchmark;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.TextBox txtResultadosBenchmark;
    }
}