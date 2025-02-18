using System.ComponentModel.DataAnnotations;
using S14L2;

CV cv = new CV();

void CompilazioneCV()
{
    Console.WriteLine("==================================================");
    Console.WriteLine("BENVENUTO NELLA COMPILAZIONE DEL TUO CV");
    Console.WriteLine("==================================================");
InserisciNome:
    Console.WriteLine();
    Console.WriteLine("Inserisci Nome");
    string responseNome = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseNome))
    {
        cv.informazioniPersonali.Nome = responseNome;
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Errore, inserire input valido"); goto InserisciNome;
    }
InserisciCognome:
    Console.WriteLine();
    Console.WriteLine("Insersci Cognome");
    string responseCognome = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseCognome))
    {
        cv.informazioniPersonali.Cognome = responseCognome;
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Errore, inserire input valido"); goto InserisciCognome;
    }
InserisciTelefono:
    Console.WriteLine();
    Console.WriteLine("Inserisci numero di telefono");
    string responseTelefono = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseTelefono) && responseTelefono.Length == 10 && int.TryParse(responseTelefono, out int telefono))
    {
        cv.informazioniPersonali.Telefono = responseTelefono;
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Errore, inserire input valido");
        goto InserisciTelefono;
    }
InsersciEmail:
    Console.WriteLine();
    Console.WriteLine("Inserisci Email");
    string responseEmail = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseEmail))
    {
        cv.informazioniPersonali.Email = responseEmail;
    }
    else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InsersciEmail; }
InserisciStudi:
    Console.WriteLine();
    Console.WriteLine("Inserisci Qualifica");
    string responseStudi = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseStudi))
    {
        cv.studi.Qualifica = responseStudi;
    }
    else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserisciStudi; }
InserisciIstituto:
    Console.WriteLine();
    Console.WriteLine("Inserisci Istituto Frequentato");
    string responseIstituto = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseIstituto))
    {
        cv.studi.Istituto = responseIstituto;
    }
    else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserisciIstituto; }
InserisciTipo:
    Console.WriteLine();
    Console.WriteLine("Inserisci il tipo di Istituto frequentato");
    string responseTipo = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseTipo))
    {
        cv.studi.Tipo = responseTipo;
    }
    else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserisciTipo; }
InserireDalStudi:
    Console.WriteLine();
    Console.WriteLine("Insersci Inizio Data Studi, in formato GG/MM/AAAA");
    string responseDalStudi = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseDalStudi) && DateOnly.TryParse(responseDalStudi, out DateOnly DalStudi))
    {
        cv.studi.Dal = DalStudi;
    }
    else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserireDalStudi; }
InserireAlStudi:
    Console.WriteLine();
    Console.WriteLine("Insersci Fine Data Studi, in formato GG/MM/AAAA");
    string responseAlStudi = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseAlStudi) && DateOnly.TryParse(responseAlStudi, out DateOnly AlStudi))
    {
        cv.studi.Al = AlStudi;
    }
    else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserireAlStudi; }
    InserireEsperienza:
    Console.WriteLine();
    Console.WriteLine("Hai esperienza lavorative da riportare nel tuo CV?");
    string responseEsperienza = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(responseEsperienza) && responseEsperienza.ToLower() == "no")
    {
        Console.WriteLine();
        Console.WriteLine("Stampa CV in corso..");
        StampaDettagliCVSuSchermo();
    }
    else if (!string.IsNullOrWhiteSpace(responseEsperienza) && responseEsperienza.ToLower() == "si")
    {
        int i = 0;
        InserireAzienda:
        cv.impiego.esperienza.Add(new Esperienza());
        Console.WriteLine();
        Console.WriteLine("Inserisci il nome dell'Azienda");
        string responseAzienda = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(responseAzienda))
        {
            cv.impiego.esperienza[i].Azienda = responseAzienda;
        }
        else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserireAzienda; }
        InserireJobTitle:
        Console.WriteLine();
        Console.WriteLine("Insersci Titolo di Lavoro");
        string responseJobTitle = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(responseJobTitle))
        {
            cv.impiego.esperienza[i].JobTitle = responseJobTitle;
        }
        else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserireJobTitle; }
        InserireDalEsperienza:
        Console.WriteLine();
        Console.WriteLine("Inserisci Inizio Impiego, in formato GG/MM/AAAA");
        string responseDalEsperienza = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(responseDalEsperienza) && DateOnly.TryParse(responseDalEsperienza, out DateOnly DalEsperienza))
        {
            cv.impiego.esperienza[i].Dal = DalEsperienza;
        }
        else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserireDalEsperienza; }
        InserireAlEsperienza:
        Console.WriteLine();
        Console.WriteLine("Inserisci Fine Impiego SE concluso, in formato GG/MM/AAAA");
        string? responseAlEsperienza = Console.ReadLine();
        if (DateOnly.TryParse(responseAlEsperienza, out DateOnly AlEsperienza)) {
            cv.impiego.esperienza[i].Al = AlEsperienza;
        }
        else if (string.IsNullOrWhiteSpace(responseAlEsperienza))
        {
            cv.impiego.esperienza[i].Al = null;
        }
        else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido o non inserire nulla"); goto InserireAlEsperienza; }
        InserireDescrizione:
        Console.WriteLine();
        Console.WriteLine("Inserisci Descrizione Impiego");
        string responseDescrizione = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(responseDescrizione))
        {
            cv.impiego.esperienza[i].Descrizione = responseDescrizione;
        }
        else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserireDescrizione; }
    InserireCompiti:
        Console.WriteLine();
        Console.WriteLine("Inserire Compiti Svolti nell'Impiego");
        string responseCompiti = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(responseCompiti))
        {
            cv.impiego.esperienza[i].Compiti = responseCompiti;
        }
        else { Console.WriteLine(); Console.WriteLine("Errore, inserire input valido"); goto InserireCompiti; }
        InserireUlteriore:
        Console.WriteLine();
        Console.WriteLine("Inserire ulteriore Esperienza di Lavoro?");
        string responseUlterioreEsperienza = Console.ReadLine();
        if (responseUlterioreEsperienza.ToLower() == "si")
        {
            i++;
            goto InserireAzienda;
        }
        else if(responseUlterioreEsperienza.ToLower() == "no")
        {
            Console.WriteLine();
            Console.WriteLine("Stampa CV in corso..");
            StampaDettagliCVSuSchermo();
        }
        else { Console.WriteLine(); Console.WriteLine("Errore, inserire SI o NO"); goto InserireUlteriore; }
    }
    else { Console.WriteLine(); Console.WriteLine("Errore, inserire SI o NO"); goto InserireEsperienza; }
}

void StampaDettagliCVSuSchermo()
{
    Console.WriteLine("==================================================");
    Console.WriteLine();
    Console.WriteLine($"CV di {cv.informazioniPersonali.Nome} {cv.informazioniPersonali.Cognome}");
    Console.WriteLine();
    Console.WriteLine("Informazioni Personali:");
    Console.WriteLine($"Nome: {cv.informazioniPersonali.Nome}");
    Console.WriteLine($"Cognome: {cv.informazioniPersonali.Cognome}");
    Console.WriteLine($"Telefono: {cv.informazioniPersonali.Telefono}");
    Console.WriteLine($"Email: {cv.informazioniPersonali.Email}");
    Console.WriteLine();
    Console.WriteLine("==================================================");
    Console.WriteLine();
    Console.WriteLine("Studi e Formazione:");
    Console.WriteLine($"Istituto: {cv.studi.Istituto}");
    Console.WriteLine($"Tipo: {cv.studi.Tipo}");
    Console.WriteLine($"Qualifica: {cv.studi.Qualifica}");
    Console.WriteLine($"Dal: {cv.studi.Dal}");
    Console.WriteLine($"Al: {cv.studi.Al}");
    Console.WriteLine();
    Console.WriteLine("==================================================");
    Console.WriteLine();
    Console.WriteLine("Esperienze Professionali:");
    foreach (var item in cv.impiego.esperienza)
    {
        Console.WriteLine($"Azienda: {item.Azienda}");
        Console.WriteLine($"Titolo di lavoro: {item.JobTitle}");
        Console.WriteLine($"Dal: {item.Dal}");
        Console.WriteLine($"Al: {item.Al}");
        Console.WriteLine($"Descrizione: {item.Descrizione}");
        Console.WriteLine($"Compiti: {item.Compiti}");
        Console.WriteLine();
    }
    Console.WriteLine("==================================================");
    Console.WriteLine();
    Console.WriteLine("Grazie e arrivederci");
    Console.WriteLine();
    Console.WriteLine("==================================================");
}

CompilazioneCV();