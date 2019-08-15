using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    public class bioroZamowien
    {
        private List<zamowienie> zamowienia;
        private pojazd wzorzec;

        public bioroZamowien(){
            zamowienia = new List<zamowienie>();
            wzorzec = new czolg("Abrams", new wieza(80, new dzialo(120, 37)));
        }

        public void zamow(string n, int i)
        {
            zamowienie tmp = new zamowienie(n, i, wzorzec);
            zamowienia.Add(tmp);
        }

        public zamowienie znajdzZmowienie(string n)
        {
            foreach(zamowienie z in zamowienia)
            {
                if (z.sprawdzNazwe(n) == true)
                {
                    return z;
                }
            }
            Console.WriteLine("Nie ma zamowienia o takiej nazwie");
            return null;
        }

        public int kontrola()
        {
            Iodwiedzajacy kontroler = new odwiedzajacyKontroler();
            foreach (zamowienie z in zamowienia)
            {
                z.akceptuj(kontroler);
            }
            return kontroler.dajWynik();
        }


    }
}
