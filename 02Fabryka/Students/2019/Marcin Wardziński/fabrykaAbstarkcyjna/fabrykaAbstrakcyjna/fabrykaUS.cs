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
    public class fabrykaUS : Ifabryka
    {
        private static fabrykaUS instancja;
        private fabrykaUS() { }

        public static fabrykaUS dajFabryke()
        {
            if (instancja == null)
            {
                instancja = new fabrykaUS();
            }
            return instancja;
        }

        public czolg.czolg zrobCzolg()
        {
            return new Abrams();
        }

        public apc.apc zrobApc()
        {
            return new LAV();
        }

        public bwp.bwp zrobBwp()
        {
            return new Bradley();
        }

        public dziala.dziala zrobDziala()
        {
            return new Panzerhaubica();
        }
    }
}
