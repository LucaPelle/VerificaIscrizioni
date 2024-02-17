using ClosedXML.Excel;
using System.Data;
using System.Text.RegularExpressions;

namespace VerificaIscrizioni
{
    internal static class Dati
    {
        private static readonly DataSet ds = new();
        private static readonly List<String> intestazioniColonneIscritti = [];
        private static List<String> intestazioniSelezionate = [];

        public class FileNonValido : Exception { };

        //inserimento datatable società nel dataset
        public static void AggiungiSocieta(DataTable input)
        {
            input.TableName = "societa";
            if (ds.Tables.Contains("societa"))
            {
                ds.Tables.Remove("societa");
            }
            ds.Tables.Add(input);
        }
        //inserimento datatable atleti nel dataset
        public static void AggiungiAtleti(DataTable input)
        {
            input.TableName = "atleti";
            if (ds.Tables.Contains("atleti"))
            {
                ds.Tables.Remove("atleti");
            }
            ds.Tables.Add(input);
        }
        //inserimento datatable iscritti nel dataset
        public static void AggiungiIscritti(DataTable input)
        {
            input.TableName = "iscritti";
            if (ds.Tables.Contains("iscritti"))
            {
                ds.Tables.Remove("iscritti");
                intestazioniColonneIscritti.Clear();
            }
            ds.Tables.Add(input);

            for (int i = 0; i < ds.Tables["iscritti"]!.Columns.Count - 1; i += 3)
                intestazioniColonneIscritti.Add(ds.Tables["iscritti"]!.Columns[i].ColumnName);
        }
        public static List<String> IntestazioneColonneIscritti()
        {
            return intestazioniColonneIscritti;
        }
        //acquisizione colonne selezionate per la comparazione
        public static void IntestazioneSelezionata(List<String> intestazioni)
        {
            intestazioniSelezionate = intestazioni;
        }

        public static int CountIscritti()
        {
            return ds.Tables["iscritti"]!.Rows.Count;
        }
        //funzione di elaborazione
        private static void Elab()
        {
            foreach (DataRow element in ds.Tables["iscritti"]!.Rows)
            {
                int weight = 0;
                //ricerca se tessera è presente tra tesseramenti
                if (!intestazioniSelezionate[0].Equals("Non utilizzare") && ds.Tables["atleti"]!.Rows.Contains(element[intestazioniSelezionate[0]]))
                {
                    //accuratezza tessera
                    element["acc" + intestazioniSelezionate[0]] = 10;
                    weight = 400;
                    //ricerca e copia riga con la tessera d'interesse
                    DataRow dr = ds.Tables["atleti"]!.Rows.Find(element[intestazioniSelezionate[0]].ToString()!.ToUpper())!;
                    element["corr" + intestazioniSelezionate[0]] = dr["NUM_TES"].ToString();
                    //valutazione campi selezionati nella finestra intestazioni
                    if (!intestazioniSelezionate[1].Equals("Non utilizzare"))
                    {
                        element["acc" + intestazioniSelezionate[1]] = VerificaStringa(element[intestazioniSelezionate[1]].ToString(), dr["COGN"].ToString());
                        element["corr" + intestazioniSelezionate[1]] = dr["COGN"].ToString();
                        weight += 20 * Convert.ToInt32(element["acc" + intestazioniSelezionate[1]]);
                    }
                    if (!intestazioniSelezionate[2].Equals("Non utilizzare"))
                    {
                        element["acc" + intestazioniSelezionate[2]] = VerificaStringa(element[intestazioniSelezionate[2]].ToString(), dr["NOME"].ToString());
                        element["corr" + intestazioniSelezionate[2]] = dr["NOME"].ToString();
                        weight += 15 * Convert.ToInt32(element["acc" + intestazioniSelezionate[2]]);
                    }
                    if (!intestazioniSelezionate[3].Equals("Non utilizzare"))
                    {
                        element["acc" + intestazioniSelezionate[3]] = VerificaData(element[intestazioniSelezionate[3]].ToString(), dr["DAT_NAS"].ToString());
#pragma warning disable CS8602 // Dereference of a possibly null reference impossible for the input format of atleti.dbf table
                        element["corr" + intestazioniSelezionate[3]] = dr["DAT_NAS"].ToString()[..10];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        weight += 10 * Convert.ToInt32(element["acc" + intestazioniSelezionate[3]]);
                    }
                    if (!intestazioniSelezionate[4].Equals("Non utilizzare"))
                    {
                        element["acc" + intestazioniSelezionate[4]] = VerificaStraniero(element[intestazioniSelezionate[4]].ToString(), dr["STRAN"].ToString());
                        element["corr" + intestazioniSelezionate[4]] = dr["STRAN"].ToString();
                        weight += 1 * Convert.ToInt32(element["acc" + intestazioniSelezionate[4]]);
                    }
                    if (!intestazioniSelezionate[5].Equals("Non utilizzare"))
                    {
                        element["acc" + intestazioniSelezionate[5]] = VerificaCategoria(element[intestazioniSelezionate[5]].ToString(), dr["CATEG"].ToString());
                        element["corr" + intestazioniSelezionate[5]] = dr["CATEG"].ToString();
                        weight += 4 * Convert.ToInt32(element["acc" + intestazioniSelezionate[5]]);
                    }
                    if (!intestazioniSelezionate[6].Equals("Non utilizzare"))
                    {
                        element["acc" + intestazioniSelezionate[6]] = VerificaSocieta(element[intestazioniSelezionate[6]].ToString(), dr["COD_SOC"].ToString());
                        element["corr" + intestazioniSelezionate[6]] = dr["COD_SOC"].ToString();
                        weight += 5 * Convert.ToInt32(element["acc" + intestazioniSelezionate[6]]);
                    }
                }
                //se la tessera non è presente nei tesseramenti o è stata indicata come "Non utilizzare" verifica cognome e nome
                else if (!intestazioniSelezionate[1].Equals("Non utilizzare") && !intestazioniSelezionate[2].Equals("Non utilizzare"))
                {
                    //selezione righe con cognome e nome d'interesse, ci possono essere più corrispondenze
                    DataRow[] rows = ds.Tables["atleti"]!.Select("COGN=\'" + element[intestazioniSelezionate[1]]!.ToString()!.Trim().Replace("'", "''") + "\' and NOME =\'" + element[intestazioniSelezionate[2]]!.ToString()!.Trim().Replace("'", "''") + "\'");
                    //se è presente almeno un risultato verifico gli altri campi
                    if (rows.Length > 0)
                    {
                        //inserimento peso e accuratezza cognome e nome
                        weight = 350;
                        element["acc" + intestazioniSelezionate[1]] = 10;
                        element["acc" + intestazioniSelezionate[2]] = 10;

                        //verifica di ulteriori parametri per cercare la corrispondenza migliore
                        //peso temporaneo
                        int tweight;
                        //matrice con le accuratezze
                        int[,] accMatrix = new int[5, rows.Length];
                        int index = 0;
                        int i = 0;
                        //ciclo sugli alteti con cognome e nome corrispondente
                        foreach (var row in rows)
                        {
                            //istanziazione peso temporaneo
                            tweight = 350;
                            if (!intestazioniSelezionate[0].Equals("Non utilizzare"))
                            {
                                accMatrix[0, i] = VerificaTessera(element[intestazioniSelezionate[0]]!.ToString(), row["NUM_TES"].ToString());
                                tweight += 10 * accMatrix[0, i];
                            }
                            if (!intestazioniSelezionate[3].Equals("Non utilizzare"))
                            {
                                accMatrix[1, i] = VerificaData(element[intestazioniSelezionate[3]]!.ToString(), row["DAT_NAS"].ToString());
                                tweight += 10 * accMatrix[1, i];
                            }
                            if (!intestazioniSelezionate[4].Equals("Non utilizzare"))
                            {
                                accMatrix[2, i] = VerificaStraniero(element[intestazioniSelezionate[4]]!.ToString(), row["STRAN"].ToString());
                                tweight += 1 * accMatrix[2, i];
                            }
                            if (!intestazioniSelezionate[5].Equals("Non utilizzare"))
                            {
                                accMatrix[3, i] = VerificaCategoria(element[intestazioniSelezionate[5]]!.ToString(), row["CATEG"].ToString());
                                tweight += 4 * accMatrix[3, i];
                            }
                            if (!intestazioniSelezionate[6].Equals("Non utilizzare"))
                            {
                                accMatrix[4, i] = VerificaSocieta(element[intestazioniSelezionate[6]]!.ToString(), row["COD_SOC"].ToString());
                                tweight += 10 * accMatrix[4, i];
                            }
                            //se il peso temporaneo è maggiore del precedente peso ne salvo l'indice della corrispondenza
                            if (tweight > weight)
                            {
                                weight = tweight;
                                index = i;
                            }
                            i++;
                        }
                        DataRow r = rows[index];
                        //inserisco i pesi del risultato migliore e associo i valori trovati
                        if (!intestazioniSelezionate[0].Equals("Non utilizzare"))
                        {
                            element["acc" + intestazioniSelezionate[0]] = accMatrix[0, index];
                            element["corr" + intestazioniSelezionate[0]] = r["NUM_TES"].ToString();
                        }
                        if (!intestazioniSelezionate[3].Equals("Non utilizzare"))
                        {
                            element["acc" + intestazioniSelezionate[3]] = accMatrix[1, index];
#pragma warning disable CS8602 // Dereference of a possibly null reference impossible for the input format of atleti.dbf table
                            element["corr" + intestazioniSelezionate[3]] = r["DAT_NAS"].ToString()[..10];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        }
                        if (!intestazioniSelezionate[4].Equals("Non utilizzare"))
                        {
                            element["acc" + intestazioniSelezionate[4]] = accMatrix[2, index];
                            element["corr" + intestazioniSelezionate[4]] = r["STRAN"].ToString();
                        }
                        if (!intestazioniSelezionate[5].Equals("Non utilizzare"))
                        {
                            element["acc" + intestazioniSelezionate[5]] = accMatrix[3, index];
                            element["corr" + intestazioniSelezionate[5]] = r["CATEG"].ToString();
                        }
                        if (!intestazioniSelezionate[6].Equals("Non utilizzare"))
                        {
                            element["acc" + intestazioniSelezionate[6]] = accMatrix[4, index];
                            element["corr" + intestazioniSelezionate[6]] = r["COD_SOC"].ToString();
                        }
                        //le intestazioni di nome e cognome devono essere per forza selezionate
                        element["corr" + intestazioniSelezionate[1]] = r["COGN"].ToString();
                        element["corr" + intestazioniSelezionate[2]] = r["NOME"].ToString();

                    }
                }
                //inserimento peso calcolato
                element["weight"] = weight;
            }
        }

        //verifica accuratezza campi possibili e ritorno realtivo valore di attendibilità
        private static int VerificaTessera(String iscr, String atl)
        {
            //verifica uguaglianza puntuale effettuata in precedenza
            //verifica carattere per carattere
            
            //pattern della tessera, due lettere e 6 numeri
            string pattern = "^[a-zA-Z]{2}[0-9]{6}$";
            //verifica pattern
            if (Regex.IsMatch(iscr, pattern, RegexOptions.IgnoreCase))
            {
                int weight = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (String.Compare(iscr[i].ToString(), atl[i].ToString(), true) == 0)
                        weight++;
                }
                if (weight < 4)
                    return 0;
                return weight;
            }
            else
            {
                for (int i = 0; i < atl.Length; i++)
                {
                    if (Regex.IsMatch(iscr, atl.Remove(i, 1).Insert(i, ".{0,3}"), RegexOptions.IgnoreCase))
                        return 4;
                }
                for (int i = 0; i < iscr.Length; i++)
                {
                    if (Regex.IsMatch(atl, iscr.Remove(i, 1).Insert(i, ".{0,3}"), RegexOptions.IgnoreCase))
                        return 2;
                }
                return 0;
            }
        }

        private static int VerificaStringa(String iscr, String atl)
        {
            //corrispondenza perfetta ignorando maiuscole e minuscole
            if (String.Equals(iscr, atl, StringComparison.InvariantCultureIgnoreCase))
                return 10;
            //corrispondenza senza simboli
            iscr = Regex.Replace(iscr, @"[^\w\s]", "");
            if (String.Equals(iscr, atl, StringComparison.InvariantCultureIgnoreCase))
                return 8;
            //corrispondenza sottostringhe tra spazi
            string[] niscr = iscr.Split(" ");
            string[] natl = atl.Split(" ");
            int weight = 0;
            foreach (string i in niscr)
            {
                if (natl.Contains(i))
                    weight++;
            }
            if (weight > 0)
                return 10 * weight / niscr.Length;
            //corrispondenza senza un carattere
            for (int i = 0; i < atl.Length; i++)
            {
                if (Regex.IsMatch(iscr, atl.Remove(i, 1).Insert(i, ".{0,3}"), RegexOptions.IgnoreCase))
                    return 5;
            }
            for (int i = 0; i < iscr.Length; i++)
            {
                if (Regex.IsMatch(atl, iscr.Remove(i, 1).Insert(i, ".{0,3}"), RegexOptions.IgnoreCase))
                    return 2;
            }
            return 0;
        }

        private static int VerificaData(String iscr, String atl)
        {
            //corrispondenza completa
            DateTime datl = DateTime.Parse(atl, new System.Globalization.CultureInfo("it-IT", false));
            if (DateTime.TryParse(iscr, new System.Globalization.CultureInfo("it-IT", false), out DateTime discr))
                if (discr.Equals(datl))
                    return 10;
            //corrispondenza anno
            if (String.Equals(datl.Year.ToString(), iscr, StringComparison.InvariantCultureIgnoreCase))
                return 8;
            //corrispondenza ultime cifre anno, almeno 2
            if (datl.Year.ToString().EndsWith(iscr) && iscr.Length > 1)
                return 5;
            return 0;
        }
        private static int VerificaStraniero(String iscr, String atl)
        {
            //corrispondenza perfetta ignorando maiuscole e minuscole
            if (String.Equals(iscr, atl, StringComparison.InvariantCultureIgnoreCase))
                return 10;
            //corrispondenza senza simboli
            iscr = Regex.Replace(iscr, @"[^\s]", "");
            if (String.Equals(iscr, atl, StringComparison.InvariantCultureIgnoreCase))
                return 8;
            //corrispondenza prima parola
            string niscr = iscr.Split(" ")[0];
            if (String.Equals(niscr, atl, StringComparison.InvariantCultureIgnoreCase))
                return 5;
            return 0;
        }
        private static int VerificaCategoria(String iscr, String atl)
        {
            if (String.Equals(iscr, atl, StringComparison.InvariantCultureIgnoreCase))
                return 10;
            int weight = 0;
            //verifica primo carattere (categoria)
            if (String.Equals(iscr[0].ToString(), atl[0].ToString(), StringComparison.InvariantCultureIgnoreCase))
                weight++;
            //verifica restanti caratteri a partire dalla fine (prima anno poi sesso)
            for (int i = 1; i < Math.Min(atl.Length, iscr.Length); i++)
            {
                if (string.Equals(iscr[^i].ToString(), atl[^i].ToString(), StringComparison.CurrentCultureIgnoreCase))
                    weight++;
            }
            return weight;
        }
        private static int VerificaSocieta(String iscr, String atl)
        {
            try
            {
                //corrispondenza codice
                string iscrn = Regex.Replace(iscr.Split(" ")[0], @"[^\w\s]", "");
                if (String.Equals(iscrn, atl, StringComparison.InvariantCultureIgnoreCase))
                    return 10;

                //verifica denominazione società
                if (ds.Tables["societa"]!.Rows.Find(atl) is null)
                    throw new FileNonValido();
                //ricerca nome società da codice società tabella atleti tesseramento
                string nomeSoc = Regex.Replace(ds.Tables["societa"]!.Rows.Find(atl)!["DENOM"].ToString()!, @"\s+", " ");

                //corrispondenza sottostringhe tra spazi
                string[] niscr = Regex.Replace(iscr, @"[^\w\s]", "").Split(" ");
                string[] natl = Regex.Replace(nomeSoc, @"[^\w\s]", "").Split(" ");
                int weight = 0;
                foreach (string i in niscr)
                {
                    foreach (string j in natl)
                        if (Regex.IsMatch(i, j, RegexOptions.IgnoreCase))
                        {
                            weight++;
                            break;
                        }
                }
                if (weight > 1)
                    return 10 * weight / natl.Length;
                //corrispondenza senza un carattere
                for (int i = 0; i < nomeSoc.Length; i++)
                {
                    if (Regex.IsMatch(iscr, nomeSoc.Remove(i, 1).Insert(i, ".{0,3}"), RegexOptions.IgnoreCase))
                        return 5;
                }
                for (int i = 0; i < iscr.Length; i++)
                {
                    if (Regex.IsMatch(nomeSoc, iscr.Remove(i, 1).Insert(i, ".{0,3}"), RegexOptions.IgnoreCase))
                        return 2;
                }
                return 0;
            }
            catch (FileNonValido ex)
            {
                string message = "Errore nell'apertura del file società! \nVerifica che i file atleti.dbf e societa.dbf siano aggiornati";
#if DEBUG
                DialogResult result = MessageBox.Show(message + "\n" + ex, "Verifica Iscrizioni", MessageBoxButtons.OK);
#else
                DialogResult result = MessageBox.Show(message + "\n" + ex.Message, "Verifica Iscrizioni", MessageBoxButtons.OK);
# endif
                if (result == DialogResult.OK)
                    Environment.Exit(1);
                return 0;
            }
        }

        public static XLWorkbook Excel()
        {
            Dati.Elab();
            //creazione istanza file excel
            var wb = new XLWorkbook();

            DataTable temp = ds.Tables["iscritti"]!.Copy();
            //spostamento colonna weigth in prima posizione
            temp.Columns["weight"]!.SetOrdinal(0);
            //inserimento datatable come primo foglio
            wb.Worksheets.Add(temp, "iscritti");
            IXLWorksheet ws = wb.Worksheet("iscritti");

            //imposta il colore della prima cella di ogni riga 
            foreach (IXLRow row in ws.Rows(2, ws.LastRowUsed().RowNumber()))
            {
                int weight = int.Parse(ws.Cell(row.RowNumber(), 1).Value.ToString());

                if (weight >= 700)
                    ws.Cell(row.RowNumber(), 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(99, 190, 23);
                else if (weight < 401)
                    ws.Cell(row.RowNumber(), 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(248, 105, 107);
                else if (weight < 501)
                    ws.Cell(row.RowNumber(), 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(251, 170, 120);
                else if (weight < 601)
                    ws.Cell(row.RowNumber(), 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(255, 235, 132);
                else if (weight < 700)
                    ws.Cell(row.RowNumber(), 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.FromArgb(177, 212, 77);

                //imposta il colore carattere di ogni cella
                for (int i = 2; i < ws.LastColumnUsed().ColumnNumber(); i += 3)
                {
                    if (intestazioniSelezionate.Contains(ws.Cell(1, i).Value.ToString()))
                    {
                        int t = int.Parse(ws.Cell(row.RowNumber(), i + 1).Value.ToString());
                        if (t > 7)
                            ws.Cell(row.RowNumber(), i).Style.Font.FontColor = ClosedXML.Excel.XLColor.FromArgb(99, 190, 23);
                        else if (t > 0)
                            ws.Cell(row.RowNumber(), i).Style.Font.FontColor = ClosedXML.Excel.XLColor.FromArgb(226, 107, 10);
                        else
                            ws.Cell(row.RowNumber(), i).Style.Font.FontColor = ClosedXML.Excel.XLColor.FromArgb(255, 0, 0);
                    }
                }
            }
            //eliminazione colonne non utilizzate
            foreach (IXLColumn col in ws.Columns())
            {
                //colonne accuratezza
                if (col.FirstCell().Value.ToString().StartsWith("acc"))
                    col.Delete();
                //colonne correzione non selezionate
                else if (col.FirstCell().Value.ToString().StartsWith("corr") && !intestazioniSelezionate.Contains(col.FirstCell().Value.ToString().Remove(0, 4)))
                    col.Delete();
            }

            //ordinamento per peso
            //ws.Range(ws.FirstCell().CellBelow(), ws.LastCellUsed()).Sort(1);

            //adatta larghezza colonne al contenuto della tabella
            ws.ColumnsUsed().AdjustToContents(2, 0.0, 15.0);

            return wb;

        }

    }
}
