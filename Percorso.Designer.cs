namespace VerificaIscrizioni
{
    partial class Percorso
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            istruzioni = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            iscrLabel = new Label();
            iscrButton = new Button();
            atlLabel = new Label();
            socLabel = new Label();
            atlButton = new Button();
            socButton = new Button();
            atlBox = new TextBox();
            socBox = new TextBox();
            iscrBox = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // istruzioni
            // 
            istruzioni.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            istruzioni.Location = new Point(40, 40);
            istruzioni.Margin = new Padding(40, 0, 40, 0);
            istruzioni.Name = "istruzioni";
            istruzioni.Size = new Size(803, 21);
            istruzioni.TabIndex = 0;
            istruzioni.Text = "Selezionare il file delle iscrizioni in formato Microsoft Excel ed i file esportati dal portale tesseramenti";
            istruzioni.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(iscrLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(iscrButton, 2, 0);
            tableLayoutPanel1.Controls.Add(atlLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(socLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(atlButton, 2, 2);
            tableLayoutPanel1.Controls.Add(socButton, 2, 1);
            tableLayoutPanel1.Controls.Add(atlBox, 1, 2);
            tableLayoutPanel1.Controls.Add(socBox, 1, 1);
            tableLayoutPanel1.Controls.Add(iscrBox, 1, 0);
            tableLayoutPanel1.Location = new Point(50, 80);
            tableLayoutPanel1.Margin = new Padding(40, 3, 40, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(793, 125);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // iscrLabel
            // 
            iscrLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            iscrLabel.AutoSize = true;
            iscrLabel.Location = new Point(0, 0);
            iscrLabel.Margin = new Padding(0);
            iscrLabel.Name = "iscrLabel";
            iscrLabel.Size = new Size(150, 40);
            iscrLabel.TabIndex = 7;
            iscrLabel.Text = "Iscrizioni";
            iscrLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iscrButton
            // 
            iscrButton.Anchor = AnchorStyles.None;
            iscrButton.Location = new Point(621, 0);
            iscrButton.Margin = new Padding(0);
            iscrButton.Name = "iscrButton";
            iscrButton.Size = new Size(150, 40);
            iscrButton.TabIndex = 1;
            iscrButton.Text = "Seleziona";
            iscrButton.UseVisualStyleBackColor = true;
            iscrButton.Click += iscrButton_Click;
            // 
            // atlLabel
            // 
            atlLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            atlLabel.AutoSize = true;
            atlLabel.Location = new Point(0, 80);
            atlLabel.Margin = new Padding(0);
            atlLabel.Name = "atlLabel";
            atlLabel.Size = new Size(150, 45);
            atlLabel.TabIndex = 6;
            atlLabel.Text = "Atleti";
            atlLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // socLabel
            // 
            socLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            socLabel.AutoSize = true;
            socLabel.Location = new Point(0, 40);
            socLabel.Margin = new Padding(0);
            socLabel.Name = "socLabel";
            socLabel.Size = new Size(150, 40);
            socLabel.TabIndex = 6;
            socLabel.Text = "Società";
            socLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // atlButton
            // 
            atlButton.Anchor = AnchorStyles.None;
            atlButton.Location = new Point(621, 82);
            atlButton.Margin = new Padding(0);
            atlButton.Name = "atlButton";
            atlButton.Size = new Size(150, 40);
            atlButton.TabIndex = 3;
            atlButton.Text = "Seleziona";
            atlButton.UseVisualStyleBackColor = true;
            atlButton.Click += atlButton_Click;
            // 
            // socButton
            // 
            socButton.Anchor = AnchorStyles.None;
            socButton.Location = new Point(621, 40);
            socButton.Margin = new Padding(0);
            socButton.Name = "socButton";
            socButton.Size = new Size(150, 40);
            socButton.TabIndex = 2;
            socButton.Text = "Seleziona";
            socButton.UseVisualStyleBackColor = true;
            socButton.Click += socButton_Click;
            // 
            // atlBox
            // 
            atlBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            atlBox.Location = new Point(150, 89);
            atlBox.Margin = new Padding(0);
            atlBox.Name = "atlBox";
            atlBox.ReadOnly = true;
            atlBox.Size = new Size(450, 27);
            atlBox.TabIndex = 99;
            atlBox.TabStop = false;
            // 
            // socBox
            // 
            socBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            socBox.Location = new Point(150, 46);
            socBox.Margin = new Padding(0);
            socBox.Name = "socBox";
            socBox.ReadOnly = true;
            socBox.Size = new Size(450, 27);
            socBox.TabIndex = 99;
            socBox.TabStop = false;
            // 
            // iscrBox
            // 
            iscrBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iscrBox.Location = new Point(150, 6);
            iscrBox.Margin = new Padding(0);
            iscrBox.Name = "iscrBox";
            iscrBox.ReadOnly = true;
            iscrBox.Size = new Size(450, 27);
            iscrBox.TabIndex = 99;
            iscrBox.TabStop = false;
            // 
            // Percorso
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(istruzioni);
            Name = "Percorso";
            Size = new Size(883, 217);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label istruzioni;
        private TableLayoutPanel tableLayoutPanel1;
        private Label socLabel;
        private Button atlButton;
        public TextBox atlBox;
        private Label atlLabel;
        public TextBox socBox;
        private Button socButton;
        public TextBox iscrBox;
        private Button iscrButton;
        private Label iscrLabel;

        public event EventHandler SelezionatoUnPercorso;
        public event EventHandler CambioFileIscrizioni;
    }
}
