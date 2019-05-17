using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fabrykaProsta.czolg;
using fabrykaProsta.dziala;
using fabrykaProsta.bwp;
using fabrykaProsta.apc;

namespace fabrykaProsta
{
    class fabryka
    {
        private static fabryka instancja;
        protected fabryka() { }

        public static fabryka dajFabryke()
        {
            if (instancja == null)
            {
                instancja = new fabryka();
            }
            return instancja;
        }

        public czolg.czolg dajCzolg(string nazwa)
        {
            switch (nazwa)
            {
                case "Abrams":
                    return new Abrams();
                case "T95":
                    return new T95();
                case "Leclerc":
                    return new Leclerc();
                case "Leopard":
                    return new Leopard();
                case "Merkava":
                    return new Merkava();
                default:
                    return null;
            }
        }

        public apc.apc dajTransporter(string nazwa)
        {
            switch (nazwa)
            {
                case "BRT60":
                    return new BRT60();
                case "LAV":
                    return new LAV();
                case "M60":
                    return new M60();
                case "Rosomak":
                    return new Rosomak();
                case "Streaker":
                    return new Streaker();
                default:
                    return null;
            }
        }

        public bwp.bwp dajBewupa(string nazwa)
        {
            switch (nazwa)
            {
                case "AMTRC":
                    return new AMTRC();
                case "BMP1":
                    return new BMP1();
                case "Bradley":
                    return new Bradley();
                case "Darlo":
                    return new Darlo();
                case "Warior":
                    return new Warior();
                default:
                    return null;
            }
        }

        public dziala.dziala dajArtylerie(string nazwa)
        {
            switch (nazwa)
            {
                case "Dana":
                    return new Dana();
                case "Grille":
                    return new Grille();
                case "Hummel":
                    return new Hummel();
                case "Krab":
                    return new Krab();
                case "Panzerhaubica":
                    return new Panzerhaubica();
                default:
                    return null;
            }
        }


    }
}
