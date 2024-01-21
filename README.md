# VerificaIscrizioni -- istruzioni per l'uso

## Selezione file

È necessario caricare tre file per l'esecuzione del programma:

<table><tbody><tr><td>Società:</td><td>il file esportato dal portale dei tesseramenti solitamente denominato SOCIETA.DBF</td></tr><tr><td>Atleti:</td><td>il file esportato dal portale dei tesseramenti solitamente denominato ATLETI.DBF</td></tr><tr><td>Iscrizioni:</td><td>un file Microsoft Excel che presenta nelle colonne i parametri di comparazione, nella prima riga l'intestazione di tali parametri e nelle righe seguenti i dati degli atleti</td></tr></tbody></table>

Dopo aver selezionato i file premere il pulsante "Apri".

## Selezione parametri di comparazione

Nelle caselle combinate è necessario inserire l'intestazione della colonna del file iscrizioni che rappresenta i parametri indicati. È obbligatorio selezionare un parametro tessera, le altre selezioni sono facoltative tramite l'opzione "Non utilizzare". È consigliato selezionare il numero più alto possibile di parametri per aumentare l'affidabilità della comparazione.  
Una volta terminata la selezione premere il pulsante "Esporta".

## Esportazione

È possibile selezionare il nome ed il percorso dove salvare il file da esportare. È possibile sovrascrivere file già presenti se selezionati, non è consentita l'esportazione se il file corrispondente è in uso ad un altro programma.  
Al termine compare una finestra che riporta l'avvenuta elaborazione e il numero di atleti esaminati.

## Guida alla lettura del report

Il programma restituisce il report come un file Microsoft Excel contenente tutti i campi presenti nel file iscrizioni segnalando la corrispondenza dei dati sulla base dei parametri di comparazione selezionati.  
L'algoritmo di comparazione valuta innanzitutto la corrispondenza della tessera federale, se non sono presenti riscontri nei tesseramenti effettua una ricerca sulla presenza di atleti col medesimo cognome e nome prendendo in considerazione il riscontro più affidabile.  
Nella prima colonna è riportata l'affidabilità del risultato evidenziata anche dal colore della prima cella di ogni riga.

|   | Affidabilità | Descrizione | Revisione |
| --- | --- | --- | --- |
| $\\color{rgb(248,105,107)}{\\textsf{390}}$ | 0 – 400 | Non è stato trovato un riscontro nei tesseramenti | Sì |
| $\\color{rgb(251,170,120)}{\\textsf{490}}$ | 401 - 500 | Il riscontro non è affidabile, i parametri corrispondenti non sono sufficienti all’identificazione dell’atleta | Sì |
| $\\color{rgb(255,235,132)}{\\textsf{590}}$ | 501 - 600 | Il riscontro è attendibile ma il nome dell’atleta con corrisponde al numero di tessera o viceversa | Sì |
| $\\color{rgb(177,212,77)}{\\textsf{690}}$ | 601 - 700 | Il riscontro è affidabile, alcuni parametri non corrispondono ma è possibile identificare l’atleta | Suggerita |
| $\\color{rgb(99,190,23)}{\\textsf{800}}$ | \> 700 | Il riscontro è certo, i parametri principali corrispondono, sono possibili non corrispondenze su un numero limitato di parametri non identificativi |   |

Nel caso in cui siano presenti omonimie con anche altri parametri corrispondenti il programma potrebbe segnalare come parzialmente corretto il riscontro. Ad esempio, nel caso di due fratelli, se corrispondono numero di tessera, società, categoria e cognome con un nome differente.  
Di un atleta ogni suo dato viene visualizzato in quatto modalità differenti:

|   | Descrizione | Revisione |
| --- | --- | --- |
| $${Cognome}$$ | Dato non utilizzato |   |
| $${\\color{red}Cognome}$$ | Dato non trovato nei tesseramenti | Sì |
| $${\\color{orange}Cognome}$$ | Dato non corrisponde a quanto presente nei tesseramenti | Sì |
| $${\\color{green}Cognome}$$ | Dato corrisponde con l’atleta individuato nei tesseramenti |   |

##### Il report restituito dal programma IscrizioneAtleti va inteso unicamente come suggerimento di verifica dei dati. L’utilizzo del programma non esclude un’approfondita ed accurata verifica delle iscrizioni.
