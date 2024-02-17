using ClosedXML.Excel;
using System.Data;

namespace VerificaIscrizioni
{
    public partial class Home : Form
    {
        public class FileNonValido : Exception { };

        //percorsi file in input
        public static string socPath = string.Empty;
        public static string atlPath = string.Empty;
        public static string iscrPath = string.Empty;

        //task di elaborazione dei file di input
        public Task[] tasks = new Task[3];

        public Home()
        {
            try { 
            InitializeComponent();

            //al cambio del file iscrizioni ricarica il dataset
            percorso1.CambioFileIscrizioni += (sender, e) =>
            {
                //caricamento iscrizioni nel Dataset
                tasks[0] = Task.Run(aperturaiscrizioni);
            };

            //ricerca file atleti e società nella stessa cartella del file iscrizioni
            percorso1.SelezionatoUnPercorso += (sender, e) =>
            {
                //verifica che iscrizioni sia selezionato
                if (iscrPath != string.Empty)
                {
                    //che società non sia già stato selezionato
                    if (socPath == string.Empty)
                    {
                        socPath = Directory.GetFiles(Path.GetDirectoryName(iscrPath), "*soc*.dbf")[0];
                        percorso1.socBox.Text = socPath;
                    }
                    //che atleti non sia stato selezionato
                    if (atlPath == string.Empty)
                    {
                        atlPath = Directory.GetFiles(Path.GetDirectoryName(iscrPath), "*atl*.dbf")[0];
                        percorso1.atlBox.Text = atlPath;
                    }
                }

                //abilitazione pulsante apri alla selezione di tutti i file se tutti i percorsi sono selezionati
                if (!string.IsNullOrEmpty(socPath) && !string.IsNullOrEmpty(atlPath) && !string.IsNullOrEmpty(iscrPath))
                    apriButton.Enabled = true;
            };
            //alla selezione della parametro tessera nome o cognome abilita il pulsante elabora previa verifica
            intestazioni1.iscrTessera.SelectedIndexChanged += (sender, e) => showElaboraButton();
            intestazioni1.iscrCognome.SelectedIndexChanged += (sender, e) => showElaboraButton();
            intestazioni1.iscrNome.SelectedIndexChanged += (sender, e) => showElaboraButton();
            }
            catch (Exception ex)
            {
                string message = "Errore inaspettato all'avvio";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
            }
        }

        private void showElaboraButton()
        {
            //verifica che l'elaborazione dei dbf sia completata
            if (tasks[1].IsCompleted && tasks[2].IsCompleted)
            {
                AvantiPanel.Cursor = Cursors.Default;
                //verifica che siano selezionati almeno la tessera oppure cognome e nome
                if (!intestazioni1.iscrTessera.Text.Equals("Non utilizzare") || (!intestazioni1.iscrCognome.Text.Equals("Non utilizzare") && !intestazioni1.iscrNome.Text.Equals("Non utilizzare")))
                {
                    esportaButton.Enabled = true;
                }
                //nel caso in cui venga rimossa la selezione
                else
                {
                    esportaButton.Enabled = false;
                }
            }
            else
            {
                //mostra il waitcursor solo sul pulsante Elabora
                AvantiPanel.Cursor = Cursors.WaitCursor;
            }
        }

        //click pulsante annulla per uscita programma
        private void annullaButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //click pulsante apri (finestra percorso1)
        private async void apriButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                apriButton.Enabled = false;

                //caricamento società nel dataset
                tasks[1] = Task.Run(aperturasocieta);

                //caricamento atleti nel dataset
                tasks[2] = Task.Run(aperturaatleti);

                tasks[1].GetAwaiter().OnCompleted(() => showElaboraButton());
                tasks[2].GetAwaiter().OnCompleted(() => showElaboraButton());

                await tasks[0];

                //popolamento e visualizzazione finestra
                intestazioni1.Aggiornamento();
                intestazioni1.Show();
                percorso1.Hide();

                //esportazione file diretta
                esportaButton.Show();
                apriButton.Hide();
                //indietroButton.Show();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                string message = "Errore nell'apertura dei file";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
            }
        }

        private static Task aperturasocieta()
        {
            try
            {
                //creazione datatable società
                DataTable dt = new("societa");
                DataColumn column;
                DataColumn[] pk = new DataColumn[1];
                column = new DataColumn
                {
                    ColumnName = "COD_SOC",
                    Unique = true,
                    ReadOnly = true
                };
                pk[0] = column;
                dt.Columns.Add(column);
                column = new DataColumn
                {
                    ColumnName = "DENOM",
                    ReadOnly = true
                };
                dt.Columns.Add(column);
                dt.PrimaryKey = pk;

                //lettura ed inserimento righe societa.dbf nella datatable
                using (var dbfDataReader = new DbfDataReader.DbfDataReader(socPath))
                {
                    while (dbfDataReader.Read())
                    {
                        var row = dt.NewRow();
                        row["COD_SOC"] = dbfDataReader["COD_SOC"];
                        row["DENOM"] = dbfDataReader["DENOM"];
                        dt.Rows.Add(row);
                    }
                }

                //aggiunta datatable al dataset
                Dati.AggiungiSocieta(dt);
                return Task.CompletedTask;
            }
            catch (FileNotFoundException ex)
            {
                string message = "Il file " + System.IO.Path.GetFileName(socPath).ToString() + " non esiste!";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Application.Restart();
                return Task.FromException(ex);
            }
            catch (Exception ex)
            {
                string message = "Errore nell'apertura del file " + System.IO.Path.GetFileName(socPath).ToString();
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
                return Task.FromException(ex);
            }
        }

        private static Task aperturaatleti()
        {
            try
            {
                //creazione datatable atleti
                DataTable dt = new("atleti");
                DataColumn column;
                DataColumn[] key = new DataColumn[1];
                var list = new List<string> { "NUM_TES", "COGN", "NOME", "DAT_NAS", "STRAN", "CATEG", "COD_SOC" };
                foreach (var s in list)
                {
                    column = new DataColumn
                    {
                        ColumnName = s
                    };
                    if (s == "NUM_TES")
                        key[0] = column;
                    column.ReadOnly = true;
                    dt.Columns.Add(column);
                }
                dt.PrimaryKey = key;

                //lettura ed inserimento atleti.dbf nella datatable
                using (var dbfDataReader = new DbfDataReader.DbfDataReader(atlPath))
                {
                    while (dbfDataReader.Read())
                    {
                        var row = dt.NewRow();
                        row["CATEG"] = dbfDataReader["CATEG"];
                        row["COD_SOC"] = dbfDataReader["COD_SOC"];
                        row["NUM_TES"] = dbfDataReader["NUM_TES"];
                        row["COGN"] = dbfDataReader["COGN"];
                        row["NOME"] = dbfDataReader["NOME"];
                        row["DAT_NAS"] = dbfDataReader["DAT_NAS"];
                        row["STRAN"] = dbfDataReader["STRAN"];
                        dt.Rows.Add(row);
                    }
                }

                //copia datatable atleti nella dataset
                Dati.AggiungiAtleti(dt);
                return Task.CompletedTask;
            }
            catch (FileNotFoundException ex)
            {
                string message = "Il file " + System.IO.Path.GetFileName(atlPath).ToString() + " non esiste!";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Application.Restart();
                return Task.FromException(ex);
            }
            catch (Exception ex)
            {
                string message = "Errore nell'apertura del file " + System.IO.Path.GetFileName(atlPath).ToString();
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
                return Task.FromException(ex);
            }
        }

        private static Task aperturaiscrizioni()
        {
            try
            {
                var workbook = new XLWorkbook(iscrPath);
                if (workbook.Worksheets.Count > 1)
                {
                    string message = "Nel file " + System.IO.Path.GetFileName(iscrPath).ToString() + " sono presenti più fogli. Il file deve contenere massimo un foglio";
                    DialogResult result = MessageBox.Show(message, "Verifica Iscrizioni", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                        Application.Exit();
                }
                //selezione primo foglio
                var ws1 = workbook.Worksheet(1);
                //verifica la presenza di almeno due righe
                if (ws1.RowCount() <= 2)
                    throw new FileNonValido();
                //creazione datatable iscrizioni
                DataTable dt = new("iscrizioni");
                //lettura prima cella di ogni colonna
                int columnnumber = ws1.FirstRow().CellsUsed().Count();
                foreach (IXLCell cell in ws1.FirstRow().CellsUsed())
                {
                    //verifica celle intestazioni nulle o vuote
                    if (cell.Value.IsBlank || cell.Value.ToString()!.Length < 1)
                        throw new FileNonValido();
                    //inserimento colonna
                    dt.Columns.Add(new DataColumn(cell.Value.ToString(), typeof(string)));
                    //inserimento colonna accuratezza
                    dt.Columns.Add(new DataColumn("acc" + cell.Value.ToString(), typeof(int)));
                    //inserimento colonna correzzione
                    dt.Columns.Add(new DataColumn("corr" + cell.Value.ToString(), typeof(string)));
                }
                //aggiunta colonna weight
                dt.Columns.Add(new DataColumn("weight", typeof(int)));
                //cancellazione riga intestazioni, non più necessaria per l'elaborazione dati
                ws1.FirstRow().Delete();
                //lettura righe file iscrizioni ed inserimento valori

                foreach (IXLRow row in ws1.Rows())
                {
                    DataRow r = dt.NewRow();
                    int i = 0;
                    foreach (IXLCell cell in row.Cells(1, columnnumber))
                    {
                        //cella con valore
                        r[i * 3] = cell.Value.ToString().RemoveDiacritics();
                        //cella accuratezza
                        r[(i * 3) + 1] = -1;
                        //cella
                        r[(i * 3) + 2] = "---";
                        i++;
                    }
                    //inserimento riga nella datatable
                    dt.Rows.Add(r);
                }
                //inserimento datatable incrizioni nel dataset
                Dati.AggiungiIscritti(dt);
                return Task.CompletedTask;
            }
            catch (FileNotFoundException ex)
            {
                string message = "Il file " + System.IO.Path.GetFileName(iscrPath).ToString() + " non esiste!";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
# endif
                if (result == DialogResult.OK)
                    Application.Restart();
                return Task.FromException(ex);
            }
            catch (IOException ex)
            {
                string message = "Errore nell'apertura del file " + System.IO.Path.GetFileName(iscrPath).ToString() + "\nVerifica che il file non sia utilizzato da un altro programma";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Application.Restart();
                return Task.FromException(ex);
            }
            catch (FileNonValido ex)
            {
                string message = "Errore nell'apertura del file " + System.IO.Path.GetFileName(iscrPath).ToString() + "\nVerifica che sia formattato correttamente";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Application.Restart();
                return Task.FromException(ex);
            }

            catch (Exception ex)
            {
                string message = "Errore nell'apertura del file " + System.IO.Path.GetFileName(iscrPath).ToString();
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
                return Task.FromException(ex);
            }
        }

        //click pulsante esporta
        private void esportaButton_Click(object sender, EventArgs e)
        {
            try
            {

                esportaButton.Enabled = false;
                Cursor = Cursors.WaitCursor;
                intestazioni1.EsportaIntestazioneColonne();
                Task<XLWorkbook> t = Task.Run(() => Dati.Excel());

                SaveFileDialog file = new()
                {
                    Title = "Scegli dove salvare il file di esportazione",
                    Filter = "Microsoft Excel|*.xlsx",
                    InitialDirectory = System.IO.Path.GetDirectoryName(iscrPath)
                };

                var saveOK = file.ShowDialog();
                //salvataggio file nel percorso impostato
                if (saveOK == DialogResult.OK)
                {
                    //attendi il risultato dell'elaborazione
                    Cursor = Cursors.WaitCursor;
                    XLWorkbook wb = t.Result;
                    //salvataggio
                    wb.SaveAs(file.FileName);
                    Cursor = Cursors.Default;
                    string message = $"Esportazione completata\n{Dati.CountIscritti()} iscizioni controllate";
                    DialogResult result = MessageBox.Show(message, "Verifica Iscrizioni", MessageBoxButtons.OK);
                    Application.Exit();
                }
                else if (saveOK == DialogResult.Cancel)
                {
                    esportaButton.Enabled = true;
                    Cursor = Cursors.Default;
                    return;
                }
            }
            catch (IOException ex)
            {
                string message = "Errore nell'esportazione del file!\nVerifica che il file non sia un uso da un altro programma";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
#endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
            }

            catch (Exception ex)
            {
                string message = "Errore nell'elaborazione dei dati, verifica la correttezza del file iscrizioni\nSe l'errore persiste contatta lo sviluppatore";
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