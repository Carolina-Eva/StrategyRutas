namespace UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboEstrategia = new ComboBox();
            btnCalcular = new Button();
            cboOrigen = new ComboBox();
            cboDestino = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            lblMetricas = new Label();
            pnlLeyenda = new Panel();
            pnlMapa = new Panel();
            btnVerHistorial = new Button();
            SuspendLayout();
            // 
            // cboEstrategia
            // 
            cboEstrategia.FormattingEnabled = true;
            cboEstrategia.Location = new Point(475, 109);
            cboEstrategia.Name = "cboEstrategia";
            cboEstrategia.Size = new Size(121, 23);
            cboEstrategia.TabIndex = 0;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(634, 97);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(121, 35);
            btnCalcular.TabIndex = 1;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // cboOrigen
            // 
            cboOrigen.FormattingEnabled = true;
            cboOrigen.Location = new Point(475, 54);
            cboOrigen.Name = "cboOrigen";
            cboOrigen.Size = new Size(121, 23);
            cboOrigen.TabIndex = 2;
            // 
            // cboDestino
            // 
            cboDestino.FormattingEnabled = true;
            cboDestino.Location = new Point(634, 54);
            cboDestino.Name = "cboDestino";
            cboDestino.Size = new Size(121, 23);
            cboDestino.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(475, 36);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 4;
            label1.Text = "Origen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(634, 36);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 5;
            label2.Text = "Destino";
            // 
            // lblMetricas
            // 
            lblMetricas.AutoSize = true;
            lblMetricas.Location = new Point(475, 149);
            lblMetricas.Name = "lblMetricas";
            lblMetricas.Size = new Size(52, 15);
            lblMetricas.TabIndex = 6;
            lblMetricas.Text = "Metricas";
            // 
            // pnlLeyenda
            // 
            pnlLeyenda.Location = new Point(475, 200);
            pnlLeyenda.Name = "pnlLeyenda";
            pnlLeyenda.Size = new Size(180, 120);
            pnlLeyenda.TabIndex = 7;
            // 
            // pnlMapa
            // 
            pnlMapa.Location = new Point(22, 25);
            pnlMapa.Name = "pnlMapa";
            pnlMapa.Size = new Size(405, 405);
            pnlMapa.TabIndex = 8;
            // 
            // btnVerHistorial
            // 
            btnVerHistorial.Location = new Point(475, 395);
            btnVerHistorial.Name = "btnVerHistorial";
            btnVerHistorial.Size = new Size(105, 35);
            btnVerHistorial.TabIndex = 9;
            btnVerHistorial.Text = "VerHistorial";
            btnVerHistorial.UseVisualStyleBackColor = true;
            btnVerHistorial.Click += btnVerHistorial_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVerHistorial);
            Controls.Add(pnlMapa);
            Controls.Add(pnlLeyenda);
            Controls.Add(lblMetricas);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboDestino);
            Controls.Add(cboOrigen);
            Controls.Add(btnCalcular);
            Controls.Add(cboEstrategia);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboEstrategia;
        private Button btnCalcular;
        private ComboBox cboOrigen;
        private ComboBox cboDestino;
        private Label label1;
        private Label label2;
        private Label lblMetricas;
        private Panel pnlLeyenda;
        private Panel pnlMapa;
        private Button btnVerHistorial;
    }
}
