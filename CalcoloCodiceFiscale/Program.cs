using CalcoloCodiceFiscale.CF_Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace CalcoloCodiceFiscale
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome, cognome, data, comune, sex;

            Console.WriteLine("Programma di Calcolo del Codice Fiscale per Stato Italiano." +
                "\nRivisto e approvato da un vero funzionario anagrafico!\n" +
                "NB Non copre i casi di omocodia.\n");

            #region inputUser
            Console.WriteLine("Ciao, inserisci per favore il tuo nome, senza l'uso di accenti:");
            do
            {
                nome = Console.ReadLine();
                if (nome == "" || !(nome.All(c => Char.IsLetter(c) || c == ' ' || c == '\''))){
                    Console.WriteLine("Dati non validabili. Riprova.");
                }
            } while (nome == "" || !(nome.All(c => Char.IsLetter(c) || c == ' ' || c == '\'')));
            nome = nome.Replace(" ", "").Replace("'", "");
            Console.WriteLine("Ciao, inserisci per favore il tuo cognome, senza l'uso di accenti:");
            do
            {
                cognome = Console.ReadLine();
                if (cognome == "" || !(cognome.All(c => Char.IsLetter(c) || c == ' ' || c == '\'')))
                {
                    Console.WriteLine("Dati non validabili. Riprova.");
                }
            } while (cognome == "" || !(cognome.All(c=> Char.IsLetter(c) || c == ' ' || c == '\'')));
            cognome = cognome.Replace(" ", "").Replace("'", "");
            Console.WriteLine("Ciao, inserisci per favore la tua data di nascita in questo formato: dd/mm/yyyy:");
            CultureInfo itIT = new CultureInfo("it-IT");
            DateTime date = new DateTime();
            do
            {
                data = Console.ReadLine();
                if (!(DateTime.TryParseExact(data, "dd/MM/yyyy", itIT, DateTimeStyles.None, out date)))
                {
                    Console.WriteLine("Dati non validabili. Riprova.");
                }
            } while (!(DateTime.TryParseExact(data, "dd/MM/yyyy", itIT, DateTimeStyles.None, out date)));
            Console.WriteLine("Ciao, inserisci per favore il tuo comune o la nazione di nascita:");
            do
            {
                comune = Console.ReadLine().ToUpper();
                if (comune == "" || !(comune.All(c => Char.IsLetter(c) || c == ' ' || c == '\'' || c == '-')))
                {
                    Console.WriteLine("Dati non validabili. Riprova.");
                }
            } while (comune == "" || !(comune.All(c => Char.IsLetter(c) || c == ' ' || c == '\'' || c == '-')));
            comune = comune.Replace("'", "").Replace("-", "");
            Console.WriteLine("Ciao, inserisci per favore il tuo gender, scrivendo M or F:");
            do
            {
                sex = Console.ReadLine().ToUpper();
                if (sex == "" || (sex != "M" && sex != "F"))
                {
                    Console.WriteLine("Dati non validabili. Riprova.");
                }
            } while (sex == "" || (sex != "M" && sex != "F"));
            #endregion

            Utente u = new Utente(nome, cognome, date, comune, sex);
            u.Print();
            CalcoloCF.Calcolo(u);

            Console.Read();
        }
    }
}


#region WIP
//Form1 nf = new Form1();
//nf.Show();
#endregion