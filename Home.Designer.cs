namespace VerificaIscrizioni
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            percorso1 = new Percorso();
            annullaButton = new Button();
            apriButton = new Button();
            intestazioni1 = new Intestazioni();
            indietroButton = new Button();
            esportaButton = new Button();
            AvantiPanel = new Panel();
            SuspendLayout();
            // 
            // percorso1
            // 
            percorso1.Location = new Point(-1, 0);
            percorso1.Name = "percorso1";
            percorso1.Size = new Size(883, 217);
            percorso1.TabIndex = 0;
            // 
            // annullaButton
            // 
            annullaButton.Location = new Point(500, 260);
            annullaButton.Name = "annullaButton";
            annullaButton.Size = new Size(150, 53);
            annullaButton.TabIndex = 10;
            annullaButton.Text = "Annulla";
            annullaButton.UseVisualStyleBackColor = true;
            annullaButton.Click += annullaButton_Click;
            // 
            // apriButton
            // 
            apriButton.Enabled = false;
            apriButton.Location = new Point(670, 260);
            apriButton.Name = "apriButton";
            apriButton.Size = new Size(150, 53);
            apriButton.TabIndex = 4;
            apriButton.Text = "Apri";
            apriButton.UseVisualStyleBackColor = true;
            apriButton.Click += apriButton_Click;
            // 
            // intestazioni1
            // 
            intestazioni1.Location = new Point(-1, 2);
            intestazioni1.Name = "intestazioni1";
            intestazioni1.Size = new Size(883, 217);
            intestazioni1.TabIndex = 7;
            intestazioni1.Visible = false;
            // 
            // indietroButton
            // 
            indietroButton.Location = new Point(330, 260);
            indietroButton.Name = "indietroButton";
            indietroButton.Size = new Size(150, 53);
            indietroButton.TabIndex = 8;
            indietroButton.Text = "Indietro";
            indietroButton.UseVisualStyleBackColor = true;
            indietroButton.Visible = false;
            // 
            // esportaButton
            // 
            esportaButton.Enabled = false;
            esportaButton.Location = new Point(670, 260);
            esportaButton.Name = "esportaButton";
            esportaButton.Size = new Size(150, 53);
            esportaButton.TabIndex = 8;
            esportaButton.Text = "Esporta";
            esportaButton.UseVisualStyleBackColor = true;
            esportaButton.Visible = false;
            esportaButton.Click += esportaButton_Click;
            // 
            // AvantiPanel
            // 
            AvantiPanel.Location = new Point(670, 260);
            AvantiPanel.Name = "AvantiPanel";
            AvantiPanel.Size = new Size(150, 53);
            AvantiPanel.TabIndex = 100;
            // 
            // Home
            // 
            AutoScaleMode = AutoScaleMode.None;
            CancelButton = annullaButton;
            ClientSize = new Size(882, 353);
            Controls.Add(indietroButton);
            Controls.Add(annullaButton);
            Controls.Add(intestazioni1);
            Controls.Add(percorso1);
            Controls.Add(esportaButton);
            Controls.Add(apriButton);
            Controls.Add(AvantiPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Home";
            Text = "Verifica Iscrizioni";
            ResumeLayout(false);
        }

        #endregion

        private Percorso percorso1;
        private Button annullaButton;
        public Button apriButton;
        private Intestazioni intestazioni1;
        private Button indietroButton;
        private Button esportaButton;
        private Panel AvantiPanel;
    }
}