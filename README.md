# VerificaIscrizioni -- istruzioni per l'uso

## Selezione file

� necessario caricare tre file per l'esecuzione del programma:

<table><tbody><tr><td>Societ�:</td><td>il file esportato dal portale dei tesseramenti solitamente denominato SOCIETA.DBF</td></tr><tr><td>Atleti:</td><td>il file esportato dal portale dei tesseramenti solitamente denominato ATLETI.DBF</td></tr><tr><td>Iscrizioni:</td><td>un file Microsoft Excel che presenta nelle colonne i parametri di comparazione, nella prima riga l'intestazione di tali parametri e nelle righe seguenti i dati degli atleti</td></tr></tbody></table>

Selezionato un file nella medesima cartella vengono ricercati e selezionati anche gli altri due, � possibile modificare la selezione indicando il file specifico.
Dopo aver selezionato i file premere il pulsante "Apri".

## Selezione parametri di comparazione

Nelle caselle combinate � necessario inserire l'intestazione della colonna del file iscrizioni che rappresenta i parametri indicati. � obbligatorio selezionare un parametro tessera, le altre selezioni sono facoltative tramite l'opzione "Non utilizzare". � consigliato selezionare il numero pi� alto possibile di parametri per aumentare l'affidabilit� della comparazione.  
Il programma effettua una ricerca automatica delle intestazioni e propone la selezione della colonna.
Una volta terminata la selezione premere il pulsante "Esporta".

## Esportazione

� possibile selezionare il nome ed il percorso dove salvare il file da esportare. � possibile sovrascrivere file gi� presenti se selezionati, non � consentita l'esportazione se il file corrispondente � in uso ad un altro programma.  
Al termine compare una finestra che riporta l'avvenuta elaborazione e il numero di atleti esaminati.

## Guida alla lettura del report

Il programma restituisce il report come un file Microsoft Excel contenente tutti i campi presenti nel file iscrizioni segnalando la corrispondenza dei dati sulla base dei parametri di comparazione selezionati.  
L'algoritmo di comparazione valuta innanzitutto la corrispondenza della tessera federale, se non sono presenti riscontri nei tesseramenti effettua una ricerca sulla presenza di atleti col medesimo cognome e nome prendendo in considerazione il riscontro pi� affidabile.  
Nella prima colonna � riportata l'affidabilit� del risultato evidenziata anche dal colore della prima cella di ogni riga.

| � | Affidabilit� | Descrizione | Revisione |
| --- | --- | --- | --- |
| $\\color{rgb(248,105,107)}{\\textsf{390}}$ | 0 � 400 | Non � stato trovato un riscontro nei tesseramenti | S� |
| $\\color{rgb(251,170,120)}{\\textsf{490}}$ | 401 - 500 | Il riscontro non � affidabile, i parametri corrispondenti non sono sufficienti all�identificazione dell�atleta | S� |
| $\\color{rgb(255,235,132)}{\\textsf{590}}$ | 501 - 600 | Il riscontro � attendibile ma il nome dell�atleta con corrisponde al numero di tessera o viceversa | S� |
| $\\color{rgb(177,212,77)}{\\textsf{690}}$ | 601 - 700 | Il riscontro � affidabile, alcuni parametri non corrispondono ma � possibile identificare l�atleta | Suggerita |
| $\\color{rgb(99,190,23)}{\\textsf{800}}$ | \> 700 | Il riscontro � certo, i parametri principali corrispondono, sono possibili non corrispondenze su un numero limitato di parametri non identificativi | � |

Nel caso in cui siano presenti omonimie con anche altri parametri corrispondenti il programma potrebbe segnalare come parzialmente corretto il riscontro. Ad esempio, nel caso di due fratelli, se corrispondono numero di tessera, societ�, categoria e cognome con un nome differente.  
Di un atleta ogni suo dato viene visualizzato in quatto modalit� differenti:

| � | Descrizione | Revisione |
| --- | --- | --- |
| $${Cognome}$$ | Dato non utilizzato | � |
| $${\\color{red}Cognome}$$ | Dato non trovato nei tesseramenti | S� |
| $${\\color{orange}Cognome}$$ | Dato non corrisponde a quanto presente nei tesseramenti | S� |
| $${\\color{green}Cognome}$$ | Dato corrisponde con l�atleta individuato nei tesseramenti | � |

##### Il report restituito dal programma IscrizioneAtleti va inteso unicamente come suggerimento di verifica dei dati. L�utilizzo del programma non esclude un�approfondita ed accurata verifica delle iscrizioni.