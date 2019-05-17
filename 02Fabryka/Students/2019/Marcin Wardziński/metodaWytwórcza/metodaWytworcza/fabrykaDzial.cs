using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using metodaWytworcza.dziala;

namespace metodaWytworcza
{
    class fabrykaDzial : fabryka
    {
        private static fabrykaDzial instancja;
        private fabrykaDzial() { }

        public static fabrykaDzial dajFabryke()
        {
            if (instancja == null)
            {
                instancja = new fabrykaDzial();
            }
            return instancja;
        }

        protected override Ipojazd buduj(string nazwa)
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
