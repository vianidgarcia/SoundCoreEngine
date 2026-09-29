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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            lblEstadisticas = new Label();
            panelNowPlaying = new Panel();
            lblNowPlaying = new Label();
            panelTransporte = new FlowLayoutPanel();
            btnPlay = new Button();
            btnPause = new Button();
            btnStop = new Button();
            progressBarPlayback = new ProgressBar();
            lblTiempoTranscurrido = new Label();
            playbackTimer = new System.Windows.Forms.Timer(components);
            panelBenchmark = new TableLayoutPanel();
            lblBenchmark = new Label();
            txtResultadosBenchmark = new TextBox();
            btnBenchmark = new Button();
            numInseccionesBenchmark = new NumericUpDown();
            panelRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            panelAcciones.SuspendLayout();
            panelPlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCola).BeginInit();
            panelNowPlaying.SuspendLayout();
            panelTransporte.SuspendLayout();
            panelBenchmark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numInseccionesBenchmark).BeginInit();
            SuspendLayout();
            // 
            // panelRegistro
            // 
            panelRegistro.BackColor = Color.FromArgb(34, 39, 46);
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
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.ForeColor = Color.FromArgb(139, 149, 161);
            lblTitulo.Location = new Point(13, 18);
            lblTitulo.Margin = new Padding(3, 8, 3, 3);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(40, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.BackColor = Color.FromArgb(45, 51, 59);
            txtTitulo.BorderStyle = BorderStyle.FixedSingle;
            txtTitulo.ForeColor = Color.FromArgb(216, 221, 227);
            txtTitulo.Location = new Point(59, 13);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(160, 23);
            txtTitulo.TabIndex = 1;
            // 
            // lblArtista
            // 
            lblArtista.AutoSize = true;
            lblArtista.ForeColor = Color.FromArgb(139, 149, 161);
            lblArtista.Location = new Point(232, 18);
            lblArtista.Margin = new Padding(10, 8, 3, 3);
            lblArtista.Name = "lblArtista";
            lblArtista.Size = new Size(44, 15);
            lblArtista.TabIndex = 2;
            lblArtista.Text = "Artista:";
            // 
            // txtArtista
            // 
            txtArtista.BackColor = Color.FromArgb(45, 51, 59);
            txtArtista.BorderStyle = BorderStyle.FixedSingle;
            txtArtista.ForeColor = Color.FromArgb(216, 221, 227);
            txtArtista.Location = new Point(282, 13);
            txtArtista.Name = "txtArtista";
            txtArtista.Size = new Size(160, 23);
            txtArtista.TabIndex = 3;
            // 
            // lblBpm
            // 
            lblBpm.AutoSize = true;
            lblBpm.ForeColor = Color.FromArgb(139, 149, 161);
            lblBpm.Location = new Point(455, 18);
            lblBpm.Margin = new Padding(10, 8, 3, 3);
            lblBpm.Name = "lblBpm";
            lblBpm.Size = new Size(35, 15);
            lblBpm.TabIndex = 4;
            lblBpm.Text = "BPM:";
            // 
            // numBpm
            // 
            numBpm.BackColor = Color.FromArgb(45, 51, 59);
            numBpm.BorderStyle = BorderStyle.FixedSingle;
            numBpm.ForeColor = Color.FromArgb(216, 221, 227);
            numBpm.Location = new Point(496, 13);
            numBpm.Maximum = new decimal(new int[] { 220, 0, 0, 0 });
            numBpm.Minimum = new decimal(new int[] { 60, 0, 0, 0 });
            numBpm.Name = "numBpm";
            numBpm.Size = new Size(60, 23);
            numBpm.TabIndex = 5;
            numBpm.Value = new decimal(new int[] { 124, 0, 0, 0 });
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.ForeColor = Color.FromArgb(139, 149, 161);
            lblDuracion.Location = new Point(569, 18);
            lblDuracion.Margin = new Padding(10, 8, 3, 3);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(71, 15);
            lblDuracion.TabIndex = 6;
            lblDuracion.Text = "Duración(s):";
            // 
            // numDuracion
            // 
            numDuracion.BackColor = Color.FromArgb(45, 51, 59);
            numDuracion.BorderStyle = BorderStyle.FixedSingle;
            numDuracion.ForeColor = Color.FromArgb(216, 221, 227);
            numDuracion.Location = new Point(646, 13);
            numDuracion.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(70, 23);
            numDuracion.TabIndex = 7;
            numDuracion.Value = new decimal(new int[] { 210, 0, 0, 0 });
            // 
            // rbPropia
            // 
            rbPropia.AutoSize = true;
            rbPropia.Checked = true;
            rbPropia.ForeColor = Color.FromArgb(139, 149, 161);
            rbPropia.Location = new Point(739, 18);
            rbPropia.Margin = new Padding(20, 8, 3, 3);
            rbPropia.Name = "rbPropia";
            rbPropia.Size = new Size(171, 19);
            rbPropia.TabIndex = 8;
            rbPropia.TabStop = true;
            rbPropia.Text = "Lista Simple Propia (Nodos)";
            rbPropia.UseVisualStyleBackColor = true;
            rbPropia.CheckedChanged += RadioEstructura_CheckedChanged;
            // 
            // rbLinkedList
            // 
            rbLinkedList.AutoSize = true;
            rbLinkedList.ForeColor = Color.FromArgb(139, 149, 161);
            rbLinkedList.Location = new Point(923, 18);
            rbLinkedList.Margin = new Padding(10, 8, 3, 3);
            rbLinkedList.Name = "rbLinkedList";
            rbLinkedList.Size = new Size(127, 19);
            rbLinkedList.TabIndex = 9;
            rbLinkedList.Text = ".NET LinkedList<T>";
            rbLinkedList.UseVisualStyleBackColor = true;
            rbLinkedList.CheckedChanged += RadioEstructura_CheckedChanged;
            // 
            // rbList
            // 
            rbList.AutoSize = true;
            rbList.ForeColor = Color.FromArgb(139, 149, 161);
            rbList.Location = new Point(20, 48);
            rbList.Margin = new Padding(10, 8, 3, 3);
            rbList.Name = "rbList";
            rbList.Size = new Size(92, 19);
            rbList.TabIndex = 10;
            rbList.Text = ".NET List<T>";
            rbList.UseVisualStyleBackColor = true;
            rbList.CheckedChanged += RadioEstructura_CheckedChanged;
            // 
            // btnCargarArchivos
            // 
            btnCargarArchivos.AutoSize = true;
            btnCargarArchivos.BackColor = Color.FromArgb(34, 39, 46);
            btnCargarArchivos.FlatAppearance.BorderSize = 1;
            btnCargarArchivos.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnCargarArchivos.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 59);
            btnCargarArchivos.FlatStyle = FlatStyle.Flat;
            btnCargarArchivos.ForeColor = Color.FromArgb(216, 221, 227);
            btnCargarArchivos.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnCargarArchivos.Cursor = Cursors.Hand;
            btnCargarArchivos.TextAlign = ContentAlignment.MiddleCenter;
            btnCargarArchivos.Location = new Point(130, 45);
            btnCargarArchivos.Margin = new Padding(15, 5, 3, 3);
            btnCargarArchivos.Name = "btnCargarArchivos";
            btnCargarArchivos.Size = new Size(130, 30);
            btnCargarArchivos.TabIndex = 11;
            btnCargarArchivos.Text = "📁 Cargar Archivos...";
            btnCargarArchivos.UseVisualStyleBackColor = false;
            btnCargarArchivos.Click += btnCargarArchivos_Click;
            // 
            // panelAcciones
            // 
            panelAcciones.BackColor = Color.FromArgb(34, 39, 46);
            panelAcciones.Controls.Add(btnEncolarFinal);
            panelAcciones.Controls.Add(btnReproducirSiguiente);
            panelAcciones.Controls.Add(btnAvanzar);
            panelAcciones.Controls.Add(btnInvertir);
            panelAcciones.Controls.Add(btnOrdenarBpm);
            panelAcciones.Controls.Add(btnPurgar);
            panelAcciones.Dock = DockStyle.Left;
            panelAcciones.FlowDirection = FlowDirection.TopDown;
            panelAcciones.Location = new Point(0, 196);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Padding = new Padding(10);
            panelAcciones.Size = new Size(220, 373);
            panelAcciones.TabIndex = 1;
            panelAcciones.WrapContents = false;
            // 
            // btnEncolarFinal
            // 
            btnEncolarFinal.BackColor = Color.FromArgb(34, 39, 46);
            btnEncolarFinal.FlatAppearance.BorderSize = 1;
            btnEncolarFinal.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnEncolarFinal.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 59);
            btnEncolarFinal.FlatStyle = FlatStyle.Flat;
            btnEncolarFinal.ForeColor = Color.FromArgb(216, 221, 227);
            btnEncolarFinal.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnEncolarFinal.Cursor = Cursors.Hand;
            btnEncolarFinal.TextAlign = ContentAlignment.MiddleCenter;
            btnEncolarFinal.Location = new Point(13, 13);
            btnEncolarFinal.Name = "btnEncolarFinal";
            btnEncolarFinal.Size = new Size(190, 34);
            btnEncolarFinal.TabIndex = 0;
            btnEncolarFinal.Text = "+ Encolar al Final";
            btnEncolarFinal.UseVisualStyleBackColor = false;
            btnEncolarFinal.Click += btnEncolarFinal_Click;
            // 
            // btnReproducirSiguiente
            // 
            btnReproducirSiguiente.BackColor = Color.FromArgb(34, 39, 46);
            btnReproducirSiguiente.FlatAppearance.BorderSize = 1;
            btnReproducirSiguiente.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnReproducirSiguiente.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 59);
            btnReproducirSiguiente.FlatStyle = FlatStyle.Flat;
            btnReproducirSiguiente.ForeColor = Color.FromArgb(216, 221, 227);
            btnReproducirSiguiente.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnReproducirSiguiente.Cursor = Cursors.Hand;
            btnReproducirSiguiente.TextAlign = ContentAlignment.MiddleCenter;
            btnReproducirSiguiente.Location = new Point(13, 53);
            btnReproducirSiguiente.Name = "btnReproducirSiguiente";
            btnReproducirSiguiente.Size = new Size(190, 34);
            btnReproducirSiguiente.TabIndex = 1;
            btnReproducirSiguiente.Text = "⏭ Reproducir Siguiente";
            btnReproducirSiguiente.UseVisualStyleBackColor = false;
            btnReproducirSiguiente.Click += btnReproducirSiguiente_Click;
            // 
            // btnAvanzar
            // 
            btnAvanzar.BackColor = Color.FromArgb(34, 39, 46);
            btnAvanzar.FlatAppearance.BorderSize = 1;
            btnAvanzar.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnAvanzar.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 59);
            btnAvanzar.FlatStyle = FlatStyle.Flat;
            btnAvanzar.ForeColor = Color.FromArgb(216, 221, 227);
            btnAvanzar.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnAvanzar.Cursor = Cursors.Hand;
            btnAvanzar.TextAlign = ContentAlignment.MiddleCenter;
            btnAvanzar.Location = new Point(13, 93);
            btnAvanzar.Name = "btnAvanzar";
            btnAvanzar.Size = new Size(190, 34);
            btnAvanzar.TabIndex = 2;
            btnAvanzar.Text = "⏩ Avanzar Pista";
            btnAvanzar.UseVisualStyleBackColor = false;
            btnAvanzar.Click += btnAvanzar_Click;
            // 
            // btnInvertir
            // 
            btnInvertir.BackColor = Color.FromArgb(34, 39, 46);
            btnInvertir.FlatAppearance.BorderSize = 1;
            btnInvertir.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnInvertir.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 59);
            btnInvertir.FlatStyle = FlatStyle.Flat;
            btnInvertir.ForeColor = Color.FromArgb(216, 221, 227);
            btnInvertir.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnInvertir.Cursor = Cursors.Hand;
            btnInvertir.TextAlign = ContentAlignment.MiddleCenter;
            btnInvertir.Location = new Point(13, 133);
            btnInvertir.Name = "btnInvertir";
            btnInvertir.Size = new Size(190, 34);
            btnInvertir.TabIndex = 3;
            btnInvertir.Text = "⇅ Invertir Lista (In-Place)";
            btnInvertir.UseVisualStyleBackColor = false;
            btnInvertir.Click += btnInvertir_Click;
            // 
            // btnOrdenarBpm
            // 
            btnOrdenarBpm.BackColor = Color.FromArgb(34, 39, 46);
            btnOrdenarBpm.FlatAppearance.BorderSize = 1;
            btnOrdenarBpm.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnOrdenarBpm.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 59);
            btnOrdenarBpm.FlatStyle = FlatStyle.Flat;
            btnOrdenarBpm.ForeColor = Color.FromArgb(216, 221, 227);
            btnOrdenarBpm.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnOrdenarBpm.Cursor = Cursors.Hand;
            btnOrdenarBpm.TextAlign = ContentAlignment.MiddleCenter;
            btnOrdenarBpm.Location = new Point(13, 173);
            btnOrdenarBpm.Name = "btnOrdenarBpm";
            btnOrdenarBpm.Size = new Size(190, 34);
            btnOrdenarBpm.TabIndex = 4;
            btnOrdenarBpm.Text = "⚡ Ordenar por Curva BPM";
            btnOrdenarBpm.UseVisualStyleBackColor = false;
            btnOrdenarBpm.Click += btnOrdenarBpm_Click;
            // 
            // btnPurgar
            // 
            btnPurgar.BackColor = Color.FromArgb(34, 39, 46);
            btnPurgar.FlatAppearance.BorderSize = 1;
            btnPurgar.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnPurgar.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 51, 59);
            btnPurgar.FlatStyle = FlatStyle.Flat;
            btnPurgar.ForeColor = Color.FromArgb(216, 221, 227);
            btnPurgar.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnPurgar.Cursor = Cursors.Hand;
            btnPurgar.TextAlign = ContentAlignment.MiddleCenter;
            btnPurgar.Location = new Point(13, 213);
            btnPurgar.Name = "btnPurgar";
            btnPurgar.Size = new Size(190, 34);
            btnPurgar.TabIndex = 5;
            btnPurgar.Text = "\U0001f9f9 Purgar Duplicados";
            btnPurgar.UseVisualStyleBackColor = false;
            btnPurgar.Click += btnPurgar_Click;
            // 
            // panelPlaylist
            // 
            panelPlaylist.BackColor = Color.FromArgb(34, 39, 46);
            panelPlaylist.Controls.Add(dgvCola);
            panelPlaylist.Controls.Add(lblEstadisticas);
            panelPlaylist.Dock = DockStyle.Fill;
            panelPlaylist.Location = new Point(220, 196);
            panelPlaylist.Name = "panelPlaylist";
            panelPlaylist.Size = new Size(880, 373);
            panelPlaylist.TabIndex = 2;
            // 
            // dgvCola
            // 
            dgvCola.AllowUserToAddRows = false;
            dgvCola.AllowUserToDeleteRows = false;
            dgvCola.Anchor = AnchorStyles.Left;
            dgvCola.BackgroundColor = Color.FromArgb(34, 39, 46);
            dgvCola.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 51, 59);
            dataGridViewCellStyle1.Font = new Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(139, 149, 161);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCola.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(34, 39, 46);
            dataGridViewCellStyle2.Font = new Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(216, 221, 227);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(45, 51, 59);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(124, 92, 255);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCola.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCola.EnableHeadersVisualStyles = false;
            dgvCola.GridColor = Color.FromArgb(58, 65, 75);
            dgvCola.Location = new Point(0, 0);
            dgvCola.Name = "dgvCola";
            dgvCola.ReadOnly = true;
            dgvCola.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCola.Size = new Size(865, 349);
            dgvCola.TabIndex = 0;
            // 
            // lblEstadisticas
            // 
            lblEstadisticas.Dock = DockStyle.Bottom;
            lblEstadisticas.ForeColor = Color.FromArgb(139, 149, 161);
            lblEstadisticas.Location = new Point(0, 349);
            lblEstadisticas.Name = "lblEstadisticas";
            lblEstadisticas.Size = new Size(880, 24);
            lblEstadisticas.TabIndex = 2;
            lblEstadisticas.Text = "Total en cola: 0";
            // 
            // panelNowPlaying
            // 
            panelNowPlaying.BackColor = Color.FromArgb(34, 39, 46);
            panelNowPlaying.Controls.Add(lblNowPlaying);
            panelNowPlaying.Controls.Add(panelTransporte);
            panelNowPlaying.Dock = DockStyle.Top;
            panelNowPlaying.Location = new Point(0, 100);
            panelNowPlaying.Name = "panelNowPlaying";
            panelNowPlaying.Size = new Size(1100, 96);
            panelNowPlaying.TabIndex = 5;
            // 
            // lblNowPlaying
            // 
            lblNowPlaying.AutoEllipsis = true;
            lblNowPlaying.Font = new Font("Tahoma", 13F, FontStyle.Bold);
            lblNowPlaying.ForeColor = Color.FromArgb(139, 149, 161);
            lblNowPlaying.Location = new Point(18, 12);
            lblNowPlaying.Name = "lblNowPlaying";
            lblNowPlaying.Size = new Size(900, 28);
            lblNowPlaying.TabIndex = 1;
            lblNowPlaying.Text = "▶ Sonando: (nada en reproducción)";
            // 
            // panelTransporte
            // 
            panelTransporte.BackColor = Color.FromArgb(34, 39, 46);
            panelTransporte.Controls.Add(btnPlay);
            panelTransporte.Controls.Add(btnPause);
            panelTransporte.Controls.Add(btnStop);
            panelTransporte.Controls.Add(progressBarPlayback);
            panelTransporte.Controls.Add(lblTiempoTranscurrido);
            panelTransporte.Location = new Point(15, 44);
            panelTransporte.Name = "panelTransporte";
            panelTransporte.Padding = new Padding(0, 3, 0, 3);
            panelTransporte.Size = new Size(1070, 44);
            panelTransporte.TabIndex = 4;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.FromArgb(124, 92, 255);
            btnPlay.FlatAppearance.BorderSize = 1;
            btnPlay.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.Font = new Font("Tahoma", 9.5F, FontStyle.Bold);
            btnPlay.ForeColor = Color.FromArgb(241, 244, 247);
            btnPlay.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnPlay.Cursor = Cursors.Hand;
            btnPlay.TextAlign = ContentAlignment.MiddleCenter;
            btnPlay.Location = new Point(3, 6);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(120, 36);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "▶ Play (Head)";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnPause
            // 
            btnPause.BackColor = Color.FromArgb(45, 51, 59);
            btnPause.FlatAppearance.BorderSize = 1;
            btnPause.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.ForeColor = Color.FromArgb(216, 221, 227);
            btnPause.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnPause.Cursor = Cursors.Hand;
            btnPause.TextAlign = ContentAlignment.MiddleCenter;
            btnPause.Location = new Point(129, 6);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(100, 36);
            btnPause.TabIndex = 1;
            btnPause.Text = "⏸ Pausar";
            btnPause.UseVisualStyleBackColor = false;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(45, 51, 59);
            btnStop.FlatAppearance.BorderSize = 1;
            btnStop.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.ForeColor = Color.FromArgb(216, 221, 227);
            btnStop.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnStop.Cursor = Cursors.Hand;
            btnStop.TextAlign = ContentAlignment.MiddleCenter;
            btnStop.Location = new Point(235, 6);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(90, 36);
            btnStop.TabIndex = 2;
            btnStop.Text = "⏹ Detener";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // progressBarPlayback
            // 
            progressBarPlayback.BackColor = Color.FromArgb(45, 51, 59);
            progressBarPlayback.Location = new Point(331, 6);
            progressBarPlayback.Maximum = 1000;
            progressBarPlayback.Name = "progressBarPlayback";
            progressBarPlayback.Size = new Size(640, 20);
            progressBarPlayback.TabIndex = 3;
            // 
            // lblTiempoTranscurrido
            // 
            lblTiempoTranscurrido.AutoSize = true;
            lblTiempoTranscurrido.ForeColor = Color.FromArgb(139, 149, 161);
            lblTiempoTranscurrido.Location = new Point(977, 3);
            lblTiempoTranscurrido.Name = "lblTiempoTranscurrido";
            lblTiempoTranscurrido.Size = new Size(72, 15);
            lblTiempoTranscurrido.TabIndex = 4;
            lblTiempoTranscurrido.Text = "00:00 / 00:00";
            // 
            // playbackTimer
            // 
            playbackTimer.Interval = 300;
            playbackTimer.Tick += PlaybackTimer_Tick;
            // 
            // panelBenchmark
            // 
            panelBenchmark.BackColor = Color.FromArgb(27, 31, 36);
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
            // 
            // lblBenchmark
            // 
            lblBenchmark.Anchor = AnchorStyles.Left;
            lblBenchmark.ForeColor = Color.FromArgb(139, 149, 161);
            lblBenchmark.Location = new Point(13, 10);
            lblBenchmark.Name = "lblBenchmark";
            lblBenchmark.Size = new Size(107, 40);
            lblBenchmark.TabIndex = 0;
            lblBenchmark.Text = "Cantidad de pistas para test de estrés:";
            // 
            // txtResultadosBenchmark
            // 
            txtResultadosBenchmark.BackColor = Color.FromArgb(20, 24, 28);
            txtResultadosBenchmark.BorderStyle = BorderStyle.FixedSingle;
            panelBenchmark.SetColumnSpan(txtResultadosBenchmark, 3);
            txtResultadosBenchmark.Dock = DockStyle.Fill;
            txtResultadosBenchmark.Font = new Font("Tahoma", 9F);
            txtResultadosBenchmark.ForeColor = Color.FromArgb(139, 149, 161);
            txtResultadosBenchmark.Location = new Point(13, 53);
            txtResultadosBenchmark.Multiline = true;
            txtResultadosBenchmark.Name = "txtResultadosBenchmark";
            txtResultadosBenchmark.ReadOnly = true;
            txtResultadosBenchmark.ScrollBars = ScrollBars.Vertical;
            txtResultadosBenchmark.Size = new Size(1074, 114);
            txtResultadosBenchmark.TabIndex = 3;
            // 
            // btnBenchmark
            // 
            btnBenchmark.AutoSize = true;
            btnBenchmark.BackColor = Color.FromArgb(124, 92, 255);
            btnBenchmark.FlatAppearance.BorderSize = 1;
            btnBenchmark.FlatAppearance.BorderColor = Color.FromArgb(58, 65, 75);
            btnBenchmark.FlatStyle = FlatStyle.Flat;
            btnBenchmark.ForeColor = Color.FromArgb(241, 244, 247);
            btnBenchmark.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnBenchmark.Cursor = Cursors.Hand;
            btnBenchmark.TextAlign = ContentAlignment.MiddleCenter;
            btnBenchmark.Location = new Point(188, 13);
            btnBenchmark.Name = "btnBenchmark";
            btnBenchmark.Size = new Size(191, 30);
            btnBenchmark.TabIndex = 2;
            btnBenchmark.Text = "🚀 Iniciar Prueba de Rendimiento";
            btnBenchmark.UseVisualStyleBackColor = false;
            btnBenchmark.Click += btnBenchmark_Click;
            // 
            // numInseccionesBenchmark
            // 
            numInseccionesBenchmark.Anchor = AnchorStyles.Left;
            numInseccionesBenchmark.BackColor = Color.FromArgb(45, 51, 59);
            numInseccionesBenchmark.BorderStyle = BorderStyle.FixedSingle;
            numInseccionesBenchmark.ForeColor = Color.FromArgb(216, 221, 227);
            numInseccionesBenchmark.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numInseccionesBenchmark.Location = new Point(126, 18);
            numInseccionesBenchmark.Maximum = new decimal(new int[] { 200000, 0, 0, 0 });
            numInseccionesBenchmark.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numInseccionesBenchmark.Name = "numInseccionesBenchmark";
            numInseccionesBenchmark.Size = new Size(55, 23);
            numInseccionesBenchmark.TabIndex = 1;
            numInseccionesBenchmark.Value = new decimal(new int[] { 20000, 0, 0, 0 });
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 31, 36);
            ClientSize = new Size(1100, 749);
            Controls.Add(panelPlaylist);
            Controls.Add(panelAcciones);
            Controls.Add(panelBenchmark);
            Controls.Add(panelNowPlaying);
            Controls.Add(panelRegistro);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";
            panelRegistro.ResumeLayout(false);
            panelRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBpm).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            panelAcciones.ResumeLayout(false);
            panelPlaylist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCola).EndInit();
            panelNowPlaying.ResumeLayout(false);
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

        private System.Windows.Forms.Panel panelNowPlaying;
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