using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budowniczy
{
    class PancernikBudowniczy : BudowniczyStatku
    {
        public PancernikBudowniczy()
        {
            statek = new Statek("Pancernik");
        }

        public override BudowniczyStatku BudujKadlub()
        {
            statek["kadlub"] = "Opancerzony kadlub";
            return this;
        }

        public override BudowniczyStatku BudujSilnik()
        {
            statek["silnik"] = "8 kotłów, 4 turbiny parowe";
            return this;
        }

        public override BudowniczyStatku BudujSter()
        {
            statek["ster"] = "Kilka sterów";
            return this;
        }

        public override BudowniczyStatku BudujWyposazenie()
        {
            statek["wyposazenie"] = "Działa okrętowe";
            return this;
        }
    }
}
