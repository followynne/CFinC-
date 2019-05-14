using CalcoloCodiceFiscale.CF_Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcoloCodiceFiscale
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Scopo applicativo
             * all'utente è chiesto di inserire i seguenti dati:
             * Nome
             * Cognome
             * Sesso
             * Data di Nascita
             * 
             * In output sarà visualizzato il codice fiscale, calcolato tramite classe statica.
             */

            Console.WriteLine("Ciao, inserisci per favore il tuo nome.");
            string no = Console.ReadLine();
            Console.WriteLine("Ciao, inserisci per favore il tuo cognome.");
            string cg = Console.ReadLine();
            Console.WriteLine("Ciao, inserisci per favore la tua data di nascita in questo formato: gg/mm/yyyy.");
            string dt = Console.ReadLine();
            CultureInfo itIT = new CultureInfo("it-IT");
            DateTime date = new DateTime();
            if (!(DateTime.TryParseExact(dt, "dd/MM/yyyy", itIT, DateTimeStyles.None, out date)))
            { return; }
            Console.WriteLine("Ciao, inserisci per favore il tuo comune di nascita.");
            string co = Console.ReadLine();
            Console.WriteLine("Ciao, inserisci per favore il tuo gender, M or F.");
            string ge = Console.ReadLine();

            Utente u = new Utente(no, cg, date, co, ge);
            u.Print();

            CalcoloCF.Calcolo(u);
            Console.Read();


        }
    }
}
