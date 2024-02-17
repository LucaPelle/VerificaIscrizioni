using System.Text.RegularExpressions;

namespace VerificaIscrizioni
{
    public partial class Intestazioni : UserControl
    {
        public Intestazioni()
        {
            InitializeComponent();
        }

        public void Aggiornamento()
        {
            ComboBox[] iscrComboList = [iscrTessera, iscrCognome, iscrNome, iscrData, iscrNaz, iscrCategoria, iscrSocieta];
            //stringa di ricerca dei nomi delle colonne 
            string[] stringaRicerca = ["[\\S]*tess[\\S]*", "[\\S]*cogn[\\S]*", "[\\S]*(?<![g])nom[\\S]*", "[\\S]*(dat|anno)[\\S]*", "[\\S]*naz[\\S]*", "[\\S]*cat[\\S]*", "[\\S]*soc[\\S]*"];
            //inserimento opzioni box della iscrComboList
            for (int j = 0; j < iscrComboList.Length; j++)
            {
                //inserimento e selezione opzione Non utilizzare
                iscrComboList[j].Items.Add("Non utilizzare");
                foreach (string intestazione in Dati.IntestazioneColonneIscritti())
                    iscrComboList[j].Items.Add(intestazione);
                //ricerca e utilizzo della colonna sulla base dell'intestazione
                if (Dati.IntestazioneColonneIscritti().FindIndex(i => Regex.IsMatch(i, stringaRicerca[j], RegexOptions.IgnoreCase)) != -1)
                {
                    iscrComboList[j].SelectedItem = iscrComboList[j].Items[1 + Dati.IntestazioneColonneIscritti().FindIndex(i => Regex.IsMatch(i, stringaRicerca[j], RegexOptions.IgnoreCase))];
                }
                //se nessun risultato seleziona non utilizzare
                else
                    iscrComboList[j].SelectedItem = iscrComboList[j].Items[0];
            }
        }

        //esporta le intestazioni delle colonne selezionate nella lista intestazioni
        public void EsportaIntestazioneColonne()
        {
            ComboBox[] iscrComboList = [iscrTessera, iscrCognome, iscrNome, iscrData, iscrNaz, iscrCategoria, iscrSocieta];
            List<String> intestazioni = [];
            foreach (ComboBox c in iscrComboList)
            {
                if (c.SelectedItem != null)
                    intestazioni.Add(c.SelectedItem.ToString());
                else
                    intestazioni.Add("Non utilizzare");
            }
            Dati.IntestazioneSelezionata(intestazioni);
        }
    }
}
