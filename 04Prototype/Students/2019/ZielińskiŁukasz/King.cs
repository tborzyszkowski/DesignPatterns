using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    [Serializable()]
    // głowna tworzona klasa
    public class King : KingPrototype
    {
        // konstruktor
        public King(string helmet, Armor cuirass, string gauntlets, string boots)
        {
            this.Helmet = helmet;
            this.Cuirass = cuirass;
            this.Gauntlets = gauntlets;
            this.Boots = boots;
        }

        // odczytanie i zapamietanie wartosci 
        public string Helmet { get; set; }
        public Armor Cuirass { get; set; }
        public string Gauntlets { get; set; }
        public string Boots { get; set; }


    }
}
