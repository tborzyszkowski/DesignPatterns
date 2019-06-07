using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    
    public abstract class KnightPrototype
    {
        public abstract KnightPrototype Clone();
    }

    public class Knight : KnightPrototype
    {
        // konstruktor
        public Knight(string helmet, string cuirass, string gauntlets, string boots)
        {
            this.Helmet = helmet;
            this.Cuirass = cuirass;
            this.Gauntlets = gauntlets;
            this.Boots = boots;
        }

        // odczytanie i zapamietanie wartosci 
        public string Helmet { get; set; }
        public string Cuirass { get; set; }
        public string Gauntlets { get; set; }
        public string Boots { get; set; }

        // klonowanie
        public override KnightPrototype Clone()
        {
            return this.MemberwiseClone() as Knight;
        }
    }



}
