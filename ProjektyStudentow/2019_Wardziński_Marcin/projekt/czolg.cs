using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    [Serializable]
    public class czolg : pojazd
    {
        private string nazwa;
        private wieza wieza;
        private int stopienUkonczenia;

        public czolg(string a, wieza b)
        {
            nazwa = a;
            wieza = b;
            stopienUkonczenia = 0;
        }

        public override void akceptuj(Iodwiedzajacy odwiedzajacy)
        {
            odwiedzajacy.odwiedz(this);
        }

        public int ileZrobiono()
        {
            return stopienUkonczenia;
        }

        public bool czyGotowe()
        {
            if(stopienUkonczenia == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void montuj()
        {
            stopienUkonczenia++;
        }
    }
}
