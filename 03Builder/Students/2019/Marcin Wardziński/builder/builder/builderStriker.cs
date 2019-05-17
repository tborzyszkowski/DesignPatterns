using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using builder.pojazd;

namespace builder
{
    class builderStriker : builderBewupow
    {
        public builderStriker()
        {
            produkt = nowy();
        }

        public bwp dajBewupa()
        {
            return produkt;
        }

        public override bwp nowy()
        {
            return new bwp();
        }

        public override builderBewupow ustawNazwe()
        {
            produkt.nazwa = "Striker";
            return this;
        }

        public override builderBewupow ustawKaliber()
        {
            produkt.kaliber = 30;
            return this;
        }

        public override builderBewupow ustawDesant()
        {
            produkt.desant = 8;
            return this;
        }

    }
}