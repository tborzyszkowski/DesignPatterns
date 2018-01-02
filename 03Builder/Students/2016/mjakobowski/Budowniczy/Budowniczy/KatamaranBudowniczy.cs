using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budowniczy
{
    class KatamaranBudowniczy : BudowniczyStatku
    {
        public KatamaranBudowniczy()
        {
            statek = new Statek("Katamaran");
        }

        public override BudowniczyStatku BudujKadlub()
        {
            statek["kadlub"] = "Plastik";
            return this;
        }

        public override BudowniczyStatku BudujSilnik()
        {
            statek["silnik"] = "Żagiel";
            return this;
        }

        public override BudowniczyStatku BudujSter()
        {
            statek["ster"] = "Żagiel :-)";
            return this;
        }

        public override BudowniczyStatku BudujWyposazenie()
        {
            statek["wyposazenie"] = "Koło ratunkowe i kapok";
            return this;
        }
    }
}
