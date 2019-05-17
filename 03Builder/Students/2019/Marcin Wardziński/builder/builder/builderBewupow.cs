using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using builder.pojazd;

namespace builder
{
    public abstract class builderBewupow
    {
        protected bwp produkt;
        public bwp BWP { get => produkt; }
        public abstract bwp nowy();

        public abstract builderBewupow ustawNazwe();
        public abstract builderBewupow ustawKaliber();
        public abstract builderBewupow ustawDesant();

        public static implicit operator bwp(builderBewupow builder)
        {
            return builder.ustawNazwe().ustawKaliber().ustawDesant().BWP;
        }
    }
}
