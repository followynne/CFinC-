using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcoloCodiceFiscale.CF_Classes
{
    static class CalcoloCF
    {
        public static void Calcolo(Utente u)
        {
            string surname = Cognome(u.Cognome);
            string name = Nome(u.Nome);
            string year = u.DataNascita.Year.ToString().Substring(2, 2);
            string month = Month(u.DataNascita.Month);
            string day = Day(u.DataNascita.Day, u.Sesso);
            string comune = Comune(u.Comune);

            string y = String.Join("", surname, name, year, month, day, comune);
            string controlChar = ControlChar(y);

            y = String.Join("", y, controlChar);

            Console.WriteLine(y);
        }

        private static string Cognome(string s) {
            string cognome = s.ToUpper();
            if (cognome.Length < 2)
            {
                return "err";
            }
            else if (cognome.Length < 3)
            {
                return (cognome += "x").ToUpper();
            }
            else
            {
                char[] strSplit = cognome.ToCharArray();
                char[] c = new char[3];
                int j = 0;
                for (int i = 0; i < strSplit.Length && j < 3; i++)
                {
                    if (strSplit[i] != 'A' && strSplit[i] != 'E' && strSplit[i] != 'I' && strSplit[i] != 'O' && strSplit[i] != 'U')
                    {
                        c[j] = strSplit[i];
                        j++;
                    }
                }
                string sC = new string(c);
                if (sC.Length < 3)
                {
                    for (int k = 0, l = s.Length - 1; k < strSplit.Length || l > 3; k++, l++)
                    {
                        if (strSplit[k] == 'A' || strSplit[k] == 'E' || strSplit[k] == 'I' || strSplit[k] == 'O' || strSplit[k] == 'U')
                        {
                            c[l] = strSplit[k];
                        }
                    }
                    return sC = string.Join("", c);
                } else
                {
                    return sC;
                }
            }

        }

        private static string Nome(string s)
        {
            string nome = s.ToUpper();
            if (nome.Length < 2)
            {
                return "err";
            }
            else if (nome.Length < 3)
            {
                return (nome += "x").ToUpper();
            }
            else
            {
                char[] strSplit = nome.ToCharArray();
                char[] c = new char[3];
                int j = 0;
                for (int i = 0; i < strSplit.Length && j < 3; i++)
                {
                    if (strSplit[i] != 'A' && strSplit[i] != 'E' && strSplit[i] != 'I' && strSplit[i] != 'O' && strSplit[i] != 'U')
                    {
                        c[j] = strSplit[i];
                        j++;
                    }
                }
                string sC = new string(c);
                if (sC.Length < 3)
                {
                    for (int k = 0, l = s.Length - 1; k < strSplit.Length || l > 3; k++, l++)
                    {
                        if (strSplit[k] == 'A' || strSplit[k] == 'E' || strSplit[k] == 'I' || strSplit[k] == 'O' || strSplit[k] == 'U')
                        {
                            c[l] = strSplit[k];
                        }
                    }
                    return sC = string.Join("", c);
                }
                else
                {
                    return sC;
                }
            }
        }

        private static string Month(int i)
        {
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(01, "A");
            d.Add(02, "B");
            d.Add(03, "C");
            d.Add(04, "D");
            d.Add(05, "E");
            d.Add(06, "H");
            d.Add(07, "L");
            d.Add(08, "M");
            d.Add(09, "P");
            d.Add(10, "R");
            d.Add(11, "S");
            d.Add(12, "T");
            return d.First(x => x.Key == i).Value;
        }

        private static string Day(int i, string s)
        {
            if (s.ToUpper() == "F")
            {
                int d = i + 40;
                return i.ToString();
            }
            else if (s.ToUpper() == "M"){
                return i.ToString();
            } else
            {
                return "err";
            }
        }

        private static string Comune(string c)
        {
            Dictionary<string, string> d = new Dictionary<string, string>()
            {
                { "Torino", "L219" }, {"Milano", "F205"}, {"Napoli", "F839" }, {"Potenza", "G942"}
            };
            try
            {
                return d.First(x => x.Key == c).Value;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private static string ControlChar(string s)
        {
            char[] x = s.ToCharArray();
            char[] pari = new char[8];
            char[] dispari = new char[8];
            int ip = 0, id = 0;
            for (int i=0; i<x.Length; i++)
            {
                if (x[i] % 2 == 0)
                {
                    pari[ip] = x[i];
                    ip++;
                } else
                {
                    dispari[id] = x[i];
                    id++;
                }
            }

            //fin qui carico i 2 array
        }

    }
}
