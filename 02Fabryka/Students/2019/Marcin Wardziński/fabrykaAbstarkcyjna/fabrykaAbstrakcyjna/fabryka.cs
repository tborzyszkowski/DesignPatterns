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
    public abstract class fabryka
    {
        private static Ifabryka instancja;
        protected fabryka(Ifabryka fab)
        {
            instancja = fab;
        }

        public czolg.czolg dajCzolg()
        {
            return instancja.zrobCzolg();
        }

        public apc.apc dajTransporter()
        {
            return instancja.zrobApc();
        }

        public bwp.bwp dajBewupa()
        {
            return instancja.zrobBwp();
        }

        public dziala.dziala dajArtylerie()
        {
            return instancja.zrobDziala();
        }


    }
}
