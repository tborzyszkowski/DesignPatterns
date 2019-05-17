using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using builder.pojazd;

namespace builder
{
    class builderRosomak : builderBewupow
    {
        public builderRosomak()
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
            produkt.nazwa = "Rosomak";
            return this;
        }

        public override builderBewupow ustawKaliber()
        {
            produkt.kaliber = 20;
            return this;
        }

        public override builderBewupow ustawDesant()
        {
            produkt.desant = 12;
            return this;
        }

    }
}
