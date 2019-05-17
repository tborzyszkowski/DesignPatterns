using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using metodaWytworcza.apc;

namespace metodaWytworcza
{
    class fabrykaApc : fabryka
    {
        private static fabrykaApc instancja;
        private fabrykaApc() { }

        public static fabrykaApc dajFabryke()
        {
            if (instancja == null)
            {
                instancja = new fabrykaApc();
            }
            return instancja;
        }

        protected override Ipojazd buduj(string nazwa)
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
    }
}
