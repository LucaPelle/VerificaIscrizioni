namespace VerificaIscrizioni
{
    public partial class Percorso : UserControl
    {
        public Percorso()
        {
            InitializeComponent();
        }

        //seleziona percorso società dbf
        private void socButton_Click(object sender, EventArgs e)
        {
            try {
                OpenFileDialog socFile = new()
                {
                    Title = "Scegli il file SOCIETA.DBF da caricare",
                    Filter = "dBase file (.dbf)|*.dbf",
                    Multiselect = false
                };
                if (socFile.ShowDialog() == DialogResult.OK && socFile.FileName != socBox.Text)
                {
                    socBox.Text = socFile.FileName;
                    Home.socPath = socFile.FileName;
                    socFile.Dispose();
                }
                SelezionatoUnPercorso("soc", e);
            }
            catch (Exception ex)
            {
                string message = "Errore di sistema nella selezione del file società";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
            }
        }

        //seleziona percorso file atleti dbf
        private void atlButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog atlFile = new()
                {
                    Title = "Scegli il file ATLETI.DBF da caricare",
                    Filter = "dBase file |*.dbf",
                    Multiselect = false
                };
                if (atlFile.ShowDialog() == DialogResult.OK && atlFile.FileName != atlBox.Text)
                {
                    atlBox.Text = atlFile.FileName;
                    Home.atlPath = atlFile.FileName;
                    atlFile.Dispose();
                }
                SelezionatoUnPercorso("atl", e);
            }
            catch (Exception ex)
            {
                string message = "Errore di sistema nella selezione del file atleti";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
            }
        }


        //seleziona percorso file excel iscrizioni
        private void iscrButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog iscrFile = new()
                {
                    Title = "Scegli il file iscrizioni da caricare",
                    Filter = "Microsoft Excel|*.xls;*.xlsx",
                    Multiselect = false
                };
                if (iscrFile.ShowDialog() == DialogResult.OK && iscrFile.FileName != iscrBox.Text)
                {
                    iscrBox.Text = iscrFile.FileName;
                    Home.iscrPath = iscrFile.FileName;
                    iscrFile.Dispose();
                    CambioFileIscrizioni(this, e);
                }
                SelezionatoUnPercorso("iscr", e);
            }
            catch (Exception ex)
            {
                string message = "Errore di sistema nella selezione del file iscrizioni";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
            }
        }
    }
}
