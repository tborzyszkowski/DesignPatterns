using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using builder.pojazd;

namespace builder
{
    class builderMerkava : builderCzolgow
    {
        public builderMerkava()
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
            produkt.nazwa = "Merkava";
            return this;
        }

        public override builderCzolgow ustawKaliber()
        {
            produkt.kaliber = 100;
            return this;
        }

        public override builderCzolgow ustawPancerz()
        {
            produkt.pancerz = 60;
            return this;
        }

    }
}
