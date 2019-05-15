using System;
using System.Collections.Generic;
using System.IO;
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
            string year = u.DataNascita.Year.ToString("0000").Substring(2, 2);
            string month = Month(u.DataNascita.Month);
            string day = Day(u.DataNascita.Day, u.Sesso);
            string placeOfBirth = PlaceOfBirth(u.Comune);

            string y = String.Join("", surname, name, year, month, day, placeOfBirth);
            string controlChar = ControlChar(y);

            //in caso di dati non coerenti, il programma esce restituendo un messaggio di errore.
            if (controlChar.Length != 1) { Console.WriteLine("Errore. Riprovare. Hai inserito dati non validi."); return;}

            Console.WriteLine(y = String.Join("", y, controlChar));
        }

        private static string Cognome(string s) {
            string cognome = s.ToUpper();
            if (cognome.Length < 2)
            {
                return "Errore. Non ammessi cognomi a una lettera.";
            }
            else if (cognome.Length < 3)
            {
                return (cognome += "X");
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
                if (j < 3)
                {
                    for (int k = 0; k < strSplit.Length && j < 3; k++)
                    {
                        if (strSplit[k] == 'A' || strSplit[k] == 'E' || strSplit[k] == 'I' || strSplit[k] == 'O' || strSplit[k] == 'U')
                        {
                            c[j] = strSplit[k];
                            j++;
                        }
                    }
                    return string.Join("", c);
                } else
                {
                    return string.Join("", c);
                }
            }

        }

        private static string Nome(string s)
        {
            string nome = s.ToUpper();
            if (nome.Length < 2)
            {
                return "Errore. Non ammessi cognomi a una lettera.";
            }
            else if (nome.Length < 3)
            {
                return (nome += "X");
            }
            else
            {
                char[] strSplit = nome.ToCharArray();
                char[] temp = new char[strSplit.Length];
                char[] c = new char[3];
                int j = 0;
                for (int i = 0; i < strSplit.Length; i++)
                {
                    if (strSplit[i] != 'A' && strSplit[i] != 'E' && strSplit[i] != 'I' && strSplit[i] != 'O' && strSplit[i] != 'U')
                    {
                        temp[j] = strSplit[i];
                        j++;
                    }
                }
                if (j < 3)
                {
                    for (int i = 0; i<j; i++)
                    {
                        c[i] = temp[i];
                    }
                    for (int k = 0, l = j; k < strSplit.Length && l < 3; k++)
                    {
                        if (strSplit[k] == 'A' || strSplit[k] == 'E' || strSplit[k] == 'I' || strSplit[k] == 'O' || strSplit[k] == 'U')
                        {
                            c[l] = strSplit[k];
                            l++;
                        }
                    }
                    return string.Join("", c);
                }
                else if (j == 3)
                {
                    for (int i = 0; i < j; i++)
                    {
                        c[i] = temp[i];
                    }
                    return string.Join("", c);
                }
                else
                {
                    c[0] = temp[0];
                    c[1] = temp[2];
                    c[2] = temp[3];
                    return string.Join("", c);
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
            if (s == "F")
            {
                return (i+40).ToString("00");
            }
            else {
                return i.ToString("00");
            }
        }

        private static string PlaceOfBirth(string c)
        {
            
            string[] sCatasto = Properties.Resources.codCatastale.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] sComuni = Properties.Resources.listacomuni.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            Dictionary<string, string> d = new Dictionary<string, string>();
            for (int i=0;i< sCatasto.Length && i<sComuni.Length; i++)
            {
                d.Add(sComuni[i], sCatasto[i]);
            }
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
            char[] x = s.ToUpper().ToCharArray();
            if (x.Length > 15) { return  "Errore."; }
            char[] pari = new char[7];
            char[] dispari = new char[8];
            int ip = 0, id = 0, cni=0;
            for (int i=0, ct = 1; i<x.Length; i++)
            {
                if (ct % 2 == 0)
                {
                    pari[ip] = x[i];
                    ip++;
                } else
                {
                    dispari[id] = x[i];
                    id++;
                }
                ct++;
            }
            Dictionary<string, int> dPari = new Dictionary<string, int>(){
                {"0", 0}, {"1", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7},
                {"8", 8}, {"9", 9},{"A", 0},{"B", 1},{"C", 2},{"D", 3},{"E", 4},{"F", 5},{"G", 6},
                {"H", 7},{"I", 8},{"J", 9},{"K", 10},{"L", 11},{"M", 12},{"N", 13},{"O", 14},{"P", 15},{"Q", 16},
                {"R", 17},{"S", 18},{"T", 19},{"U", 20},{"V", 21},{"W", 22},{"X", 23},{"Y", 24},{"Z", 25}
            };
            Dictionary<string, int> dDispari = new Dictionary<string, int>(){
                {"0", 1}, {"1", 0}, {"2", 5}, {"3", 7}, {"4", 9}, {"5", 13}, {"6", 15}, {"7", 17},
                {"8", 19}, {"9", 21},{"A", 1},{"B", 0},{"C", 5},{"D", 7},{"E", 9},{"F", 13},{"G", 15},
                {"H", 17},{"I", 19},{"J", 21},{"K", 2},{"L", 4},{"M", 18},{"N", 20},{"O", 11},{"P", 3},{"Q", 6},
                {"R", 8},{"S", 12},{"T", 14},{"U", 16},{"V", 10},{"W", 22},{"X", 25},{"Y", 24},{"Z", 23}
            };
            Dictionary<int, string> dCni = new Dictionary<int, string>(){
                {0, "A"}, {1, "B"}, {2, "C"}, {3, "D"}, {4, "E"}, {5, "F"}, {6, "G"}, {7, "H"},
                {8, "I"}, {9, "J"},{10, "K"},{11, "L"},{12, "M"},{13, "N"},{14, "O"},{15, "P"},{16, "Q"},
                {17, "R"},{18, "S"},{19, "T"},{20, "U"},{21, "V"},{22, "W"},{23, "X"},{24, "Y"},{25, "Z" }
            };
            for (int k = 0; k<7;k++)
            {
                cni += dPari.First(z => z.Key == pari[k].ToString()).Value;
            }
            for (int i = 0; i<8; i++)
            {
                cni += dDispari.First(z => z.Key == dispari[i].ToString()).Value;
            }
            return dCni.First(z => z.Key == (cni%=26)).Value;
        }
    }
}
