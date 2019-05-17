using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using builder.pojazd;

namespace builder
{
    class builderAbrams : builderCzolgow
    {
        public builderAbrams()
        {
            produkt = nowy();
        }

        public czolg dajCzolg()
        {
            return produkt;
        }

        public override czolg nowy()
        {
            return new czolg();
        }

        public override builderCzolgow ustawNazwe()
        {
            produkt.nazwa = "Abrams";
            return this;
        }

        public override builderCzolgow ustawKaliber()
        {
            produkt.kaliber = 120;
            return this;
        }

        public override builderCzolgow ustawPancerz()
        {
            produkt.pancerz = 100;
            return this;
        }

    }
}
