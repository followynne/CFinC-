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
            #region consegna
            /* Scopo applicativo
             * all'utente è chiesto di inserire i seguenti dati:
             * Nome
             * Cognome
             * Sesso
             * Data di Nascita
             * 
             * In output sarà visualizzato il codice fiscale, calcolato tramite classe statica.
             */
            #endregion
            string nome, cognome, data, comune, sex;
            #region inputUser
            Console.WriteLine("Ciao, inserisci per favore il tuo nome.");
            do
            {
                nome = Console.ReadLine();
            } while (nome == "" || !(nome.All(Char.IsLetter)));
            Console.WriteLine("Ciao, inserisci per favore il tuo cognome.");
            do
            {
                cognome = Console.ReadLine();
            } while (cognome == "" || !(cognome.All(Char.IsLetter)));
            Console.WriteLine("Ciao, inserisci per favore la tua data di nascita in questo formato: gg/mm/yyyy.");
            CultureInfo itIT = new CultureInfo("it-IT");
            DateTime date = new DateTime();
            do {
                data = Console.ReadLine();
            } while (!(DateTime.TryParseExact(data, "dd/MM/yyyy", itIT, DateTimeStyles.None, out date)));
            Console.WriteLine("Ciao, inserisci per favore il tuo comune di nascita. Se alla fine restituisce errore, riprova modificando le iniziali " +
                "in maiuscolo/viceversa. Come consiglio, le parole di +3 lettere iniziano in maiuscolo (es.San), il resto in minuscolo.");
            do
            {
                comune = Console.ReadLine();
            } while (comune == "" || !(comune.All(c => Char.IsLetter(c) || c == ' ')));
            Console.WriteLine("Ciao, inserisci per favore il tuo gender, scrivendo M or F.");
            do
            {
                sex = Console.ReadLine().ToUpper();
            } while (sex == "" || (sex != "M" && sex != "F"));
            #endregion
        
            Utente u = new Utente(nome, cognome, date, comune, sex);
            u.Print();
            CalcoloCF.Calcolo(u);


            Console.Read();
        }
    }
}
