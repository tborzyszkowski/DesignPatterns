using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fabrykaAbstrakcyjna.czolg;
using fabrykaAbstrakcyjna.dziala;
using fabrykaAbstrakcyjna.bwp;
using fabrykaAbstrakcyjna.apc;

namespace fabrykaAbstrakcyjna
{
    public class fabrykaEU : Ifabryka
    {
        private static fabrykaEU instancja;
        private fabrykaEU() { }

        public static fabrykaEU dajFabryke()
        {
            if (instancja == null)
            {
                instancja = new fabrykaEU();
            }
            return instancja;
        }

        public czolg.czolg zrobCzolg()
        {
            return new Leclerc();
        }

        public apc.apc zrobApc()
        {
            return new Rosomak();
        }

        public bwp.bwp zrobBwp()
        {
            return new Darlo();
        }

        public dziala.dziala zrobDziala()
        {
            return new Krab();
        }
    }
}
