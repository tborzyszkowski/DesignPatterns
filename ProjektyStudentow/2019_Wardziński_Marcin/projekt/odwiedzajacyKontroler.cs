using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    public class odwiedzajacyKontroler : Iodwiedzajacy
    {
        private int zapotrzebowanie;

        public odwiedzajacyKontroler()
        {
            zapotrzebowanie = 0;
        }

        public void odwiedz(pojazd poj)
        {
            czolg cz = poj as czolg;
            int wykonanie = cz.ileZrobiono();
            zapotrzebowanie = zapotrzebowanie + (10 - wykonanie);
        }

        public int dajWynik()
        {
            return zapotrzebowanie;
        }


    }
}
