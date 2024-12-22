# CaioDexelop

CaioDexelop è un'applicazione ASP.NET Core MVC che utilizza Entity Framework Core per la gestione dei dati dei utenti. Questo progetto include la configurazione del contesto del database, la migrazione e il seeding dei dati.

## Prerequisiti

*   .NET SDK 9.0 (o versione successiva compatibile): [Download .NET](https://dotnet.microsoft.com/download)
*   SQL Server (Express Edition o versione completa): [Download SQL Server Express](https://www.microsoft.com/it-it/sql-server/sql-server-downloads)

**Nota:** Per SQL Server, è possibile utilizzare anche un'istanza locale di SQL Server (LocalDB) se configurata correttamente.

## Configurazione

1. Clona il repository: 
	git clone https://github.com/iacoleite/CaioDexelop

2. Configura la stringa di connessione nel file `appsettings.json`. Questo file contiene le impostazioni di connessione al database.
Devi sostituire la stringa predefinita con quella corretta per il tuo ambiente.
Apri il file `appsettings.json` e cerca la sezione `ConnectionStrings`. Dovresti trovare una voce simile a questa:

  "ConnectionStrings": {
    "CaioDexelopContext": "Server=(localdb)\\mssqllocaldb;Database=CaioDexelopContext-f36e5653-91f0-4033-b3fb-31655002cd88;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
Modifica il valore di CaioDexelopContext con la tua stringa di connessione. Ad esempio:

Se usi un database SQL Server locale con un nome specifico: "Server=.\\SQLEXPRESS;Database=MioDatabase;Trusted_Connection=True;"
Se usi un database su un server remoto: "Server=indirizzo_server;Database=MioDatabase;User Id=mio_utente;Password=mia_password;"
Ricorda di sostituire i valori segnaposto (come MioDatabase, indirizzo_server, mio_utente, mia_password) con le tue informazioni reali.

## Esecuzione dell'applicazione

1. Avvio e configurazione automatica del database:

L'applicazione può essere avviata in due modalità:
*   Solo HTTP: `dotnet run` (utilizza il profilo "http" predefinito).
*   HTTP e HTTPS: `dotnet run --launch-profile https` (utilizza il profilo "https" configurato per entrambi i protocolli).

Il file `launchSettings.json` contiene la configurazione dei profili di avvio.

Alla prima esecuzione, o nel caso in cui il database non esista o sia vuoto, il framework si occuperà automaticamente di:
*   Creare il database.
*   Applicare le migrazioni per la creazione delle tabelle.
*   Popolare il database con i dati iniziali (definiti nel codice tramite *seeding* (UtenteSeeder.cs)).

Questo processo automatico semplifica la configurazione iniziale dell'applicazione.

2. Apri il browser e naviga a `https://localhost:7119` o 'http://localhost:5169'.

## Configurazione del Database (Opzionale)

Questo passaggio è *totalmente opzionale*.

I comandi SQL per creare il database e inserire dati casuali sono disponibili nel file `DBinstructions.txt`. 

**Passaggi riassunti:**

1.  Connettiti al tuo server SQL usando uno strumento come SQL Server Management Studio (SSMS) o `sqlcmd`.
2.  Esegui i comandi SQL contenuti nel file `DBinstructions.txt` nell'ordine in cui appaiono.

**Nota:** Assicurati di configurare la stringa di connessione nel file `appsettings.json` per puntare al database che hai creato.

## Struttura del Progetto

- `CaioDexelop/Program.cs`: Configurazione principale dell'applicazione.
- `CaioDexelop/Data/CaioDexelopContext.cs`: Contesto del database.
- `CaioDexelop/Migrations/`: Cartella contenente le migrazioni del database.
- `CaioDexelop/Models/`: Modelli di dati.
- `CaioDexelop/Controllers/`: Controller per la gestione delle richieste HTTP.
- `CaioDexelop/Views/`: Viste per la presentazione dei dati.
