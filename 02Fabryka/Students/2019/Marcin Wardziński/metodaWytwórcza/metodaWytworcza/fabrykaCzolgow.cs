using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using metodaWytworcza.czolg;

namespace metodaWytworcza
{
    class fabrykaCzolgow : fabryka
    {
        private static fabrykaCzolgow instancja;
        private fabrykaCzolgow() { }

        public static fabrykaCzolgow dajFabryke()
        {
            if (instancja == null)
            {
                instancja = new fabrykaCzolgow();
            }
            return instancja;
        }

        protected override Ipojazd buduj(string nazwa)
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
    }
}
