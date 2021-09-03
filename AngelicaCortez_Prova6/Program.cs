using AngelicaCortez_Prova6.Client;
using System;

namespace AngelicaCortez_Prova6
{
    class Program
    {
        //        Realizzare un sistema di gestione di un’agenzia di assicurazione che si basi su:
        //- Un database Assicurazione(SQL Server), costituito dalle tabelle
        //o Clienti
        //Id(int, PK, auto-incrementale)
        //Codice fiscale(nchar(16), not nullable)
        //Nome(varchar(30))
        //Cognome(varchar(20))
        //o Polizze
        //Id(int, PK, auto-incrementale)
        //NumeroPolizza(int, not nullable)
        //DataScadenza(date)
        //RataMensile(decimal)
        //Tipo(RCAuto, Furto, Vita)
        //Il cliente può stipulare più polizze ma ogni polizza è ‘personalizzata’ per un
        //cliente.
        //- Una Console app che consenta all’assicuratore di:
        //• Inserire un nuovo cliente
        //• Inserire una polizza per un cliente già esistente
        //• Visualizzare le polizze di un cliente
        //• Posticipare la data di scadenza(per es. quando si rinnova una polizza)
        //• Visualizzare i clienti che hanno una polizza vita(OPZIONALE)
       
        //VINCOLI TECNICI
        //• Utilizzare Entity Framework Core
        //• Utilizzare l'approccio Code-First e le Migrations
        //OPZIONALE: Implementare una o più delle funzionalità utilizzando
        //ADO.NET(Connected mode)
        static void Main(string[] args)
        {
            Menu.Start();
        }
    }
}
