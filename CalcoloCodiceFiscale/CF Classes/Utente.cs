using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcoloCodiceFiscale.CF_Classes
{
    class Utente
    {

        public Utente(string nome, string cognome, DateTime dataNascita, string comune, string sesso)
        {
            _nome = nome;
            _cognome = cognome;
            _dateTime = dataNascita;
            _comune = comune;
            _sesso = sesso;
        }
        #region getset
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _cognome;

        public string Cognome
        {
            get { return _cognome; }
            set {_cognome = value;}
        }

        private DateTime _dateTime;

        public DateTime DataNascita
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        private string _comune;

        public string Comune
        {
            get { return _comune; }
            set { _comune = value; }
        }

        private string _sesso;

        public string Sesso
        {
            get { return _sesso; }
            set { _sesso = value; }
        }
        #endregion
        

        public void Print()
        {
            Console.Write(_nome + " " + _cognome + " " + _dateTime + " " + _comune + " " + _sesso + "\n");
        }
       

    }
}
