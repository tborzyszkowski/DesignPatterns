using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    public class zamowienie
    {
        private string nazwa;
        private List<pojazd> lista = new List<pojazd>();

        public zamowienie(string naz, int ile, pojazd wzorzec)
        {
            nazwa = naz;
            pojazd tmp;
            for(int i = 0; i<ile; i++)
            {
                tmp = wzorzec.kopiuj();
                lista.Add(tmp);
            }
        }

        public void akceptuj(Iodwiedzajacy odwiedzajacy)
        {
            foreach(pojazd p in lista)
            {
                p.akceptuj(odwiedzajacy);
            }
        }

        public bool sprawdzNazwe(string a)
        {
            if(nazwa.Equals(a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
