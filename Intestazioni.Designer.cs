namespace VerificaIscrizioni
{
    partial class Intestazioni
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
            tesseraText = new Label();
            iscrTessera = new ComboBox();
            cognomeText = new Label();
            iscrCognome = new ComboBox();
            nomeText = new Label();
            iscrNome = new ComboBox();
            dataText = new Label();
            iscrData = new ComboBox();
            annoText = new Label();
            iscrSocieta = new ComboBox();
            iscrCategoria = new ComboBox();
            categoraText = new Label();
            societaText = new Label();
            iscrNaz = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // istruzioni
            // 
            istruzioni.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            istruzioni.Location = new Point(40, 40);
            istruzioni.Margin = new Padding(40, 0, 40, 0);
            istruzioni.Name = "istruzioni";
            istruzioni.Size = new Size(803, 20);
            istruzioni.TabIndex = 1;
            istruzioni.Text = "Associare i parametri di confronto con le colonne presenti nei file selezionati";
            istruzioni.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28554F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28554F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28554F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28554F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28554F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28411F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28817F));
            tableLayoutPanel1.Controls.Add(tesseraText, 0, 0);
            tableLayoutPanel1.Controls.Add(iscrTessera, 0, 1);
            tableLayoutPanel1.Controls.Add(cognomeText, 1, 0);
            tableLayoutPanel1.Controls.Add(iscrCognome, 1, 1);
            tableLayoutPanel1.Controls.Add(nomeText, 2, 0);
            tableLayoutPanel1.Controls.Add(iscrNome, 2, 1);
            tableLayoutPanel1.Controls.Add(dataText, 3, 0);
            tableLayoutPanel1.Controls.Add(iscrData, 3, 1);
            tableLayoutPanel1.Controls.Add(annoText, 4, 0);
            tableLayoutPanel1.Controls.Add(iscrSocieta, 6, 1);
            tableLayoutPanel1.Controls.Add(iscrCategoria, 5, 1);
            tableLayoutPanel1.Controls.Add(categoraText, 5, 0);
            tableLayoutPanel1.Controls.Add(societaText, 6, 0);
            tableLayoutPanel1.Controls.Add(iscrNaz, 4, 1);
            tableLayoutPanel1.Location = new Point(40, 80);
            tableLayoutPanel1.Margin = new Padding(40, 3, 40, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(803, 125);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tesseraText
            // 
            tesseraText.AutoSize = true;
            tesseraText.Location = new Point(3, 0);
            tesseraText.Name = "tesseraText";
            tesseraText.Padding = new Padding(5);
            tesseraText.Size = new Size(73, 30);
            tesseraText.TabIndex = 0;
            tesseraText.Text = "Tessera*";
            // 
            // iscrTessera
            // 
            iscrTessera.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iscrTessera.FormattingEnabled = true;
            iscrTessera.Location = new Point(3, 73);
            iscrTessera.Name = "iscrTessera";
            iscrTessera.Size = new Size(108, 28);
            iscrTessera.TabIndex = 1;
            // 
            // cognomeText
            // 
            cognomeText.AutoSize = true;
            cognomeText.Location = new Point(117, 0);
            cognomeText.Name = "cognomeText";
            cognomeText.Padding = new Padding(5);
            cognomeText.Size = new Size(84, 30);
            cognomeText.TabIndex = 1;
            cognomeText.Text = "Cognome";
            // 
            // iscrCognome
            // 
            iscrCognome.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iscrCognome.FormattingEnabled = true;
            iscrCognome.Location = new Point(117, 73);
            iscrCognome.Name = "iscrCognome";
            iscrCognome.Size = new Size(108, 28);
            iscrCognome.TabIndex = 2;
            // 
            // nomeText
            // 
            nomeText.AutoSize = true;
            nomeText.Location = new Point(231, 0);
            nomeText.Name = "nomeText";
            nomeText.Padding = new Padding(5);
            nomeText.Size = new Size(60, 30);
            nomeText.TabIndex = 2;
            nomeText.Text = "Nome";
            // 
            // iscrNome
            // 
            iscrNome.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iscrNome.FormattingEnabled = true;
            iscrNome.Location = new Point(231, 73);
            iscrNome.Name = "iscrNome";
            iscrNome.Size = new Size(108, 28);
            iscrNome.TabIndex = 3;
            // 
            // dataText
            // 
            dataText.AutoSize = true;
            dataText.Location = new Point(345, 0);
            dataText.Name = "dataText";
            dataText.Padding = new Padding(5);
            dataText.Size = new Size(72, 50);
            dataText.TabIndex = 3;
            dataText.Text = "Data di nascita";
            // 
            // iscrData
            // 
            iscrData.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iscrData.FormattingEnabled = true;
            iscrData.Location = new Point(345, 73);
            iscrData.Name = "iscrData";
            iscrData.Size = new Size(108, 28);
            iscrData.TabIndex = 4;
            // 
            // annoText
            // 
            annoText.AutoSize = true;
            annoText.Location = new Point(459, 0);
            annoText.Name = "annoText";
            annoText.Padding = new Padding(5);
            annoText.Size = new Size(95, 30);
            annoText.TabIndex = 13;
            annoText.Text = "Nazionalità";
            // 
            // iscrSocieta
            // 
            iscrSocieta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iscrSocieta.FormattingEnabled = true;
            iscrSocieta.Location = new Point(687, 73);
            iscrSocieta.Name = "iscrSocieta";
            iscrSocieta.Size = new Size(113, 28);
            iscrSocieta.TabIndex = 7;
            // 
            // iscrCategoria
            // 
            iscrCategoria.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iscrCategoria.FormattingEnabled = true;
            iscrCategoria.Location = new Point(573, 73);
            iscrCategoria.Name = "iscrCategoria";
            iscrCategoria.Size = new Size(108, 28);
            iscrCategoria.TabIndex = 6;
            // 
            // categoraText
            // 
            categoraText.AutoSize = true;
            categoraText.Location = new Point(573, 0);
            categoraText.Name = "categoraText";
            categoraText.Padding = new Padding(5);
            categoraText.Size = new Size(84, 30);
            categoraText.TabIndex = 14;
            categoraText.Text = "Categoria";
            // 
            // societaText
            // 
            societaText.AutoSize = true;
            societaText.Location = new Point(687, 0);
            societaText.Name = "societaText";
            societaText.Padding = new Padding(5);
            societaText.Size = new Size(68, 30);
            societaText.TabIndex = 15;
            societaText.Text = "Società";
            // 
            // iscrNaz
            // 
            iscrNaz.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            iscrNaz.FormattingEnabled = true;
            iscrNaz.Location = new Point(459, 73);
            iscrNaz.Name = "iscrNaz";
            iscrNaz.Size = new Size(108, 28);
            iscrNaz.TabIndex = 5;
            // 
            // Intestazioni
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(istruzioni);
            Name = "Intestazioni";
            Size = new Size(883, 217);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label istruzioni;
        private TableLayoutPanel tableLayoutPanel1;
        private Label dataText;
        private Label nomeText;
        private Label cognomeText;
        private Label tesseraText;
        public ComboBox iscrData;
        public ComboBox iscrCognome;
        public ComboBox iscrTessera;
        public ComboBox iscrNome;
        public ComboBox iscrCategoria;
        public ComboBox iscrSocieta;
        private Label annoText;
        private Label categoraText;
        private Label societaText;
        public ComboBox iscrNaz;
    }
}
