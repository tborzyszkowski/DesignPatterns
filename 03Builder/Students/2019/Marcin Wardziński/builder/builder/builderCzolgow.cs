using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using builder.pojazd;

namespace builder
{
    public abstract class builderCzolgow
    {
        protected czolg produkt;
        public czolg Czolg { get => produkt; }
        public abstract czolg nowy();

        public abstract builderCzolgow ustawNazwe();
        public abstract builderCzolgow ustawKaliber();
        public abstract builderCzolgow ustawPancerz();

        public static implicit operator czolg(builderCzolgow builder)
        {
            return builder.ustawNazwe().ustawKaliber().ustawPancerz().Czolg;
        }
    }
}
