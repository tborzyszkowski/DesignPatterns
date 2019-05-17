using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using metodaWytworcza.czolg;
using metodaWytworcza.dziala;
using metodaWytworcza.bwp;
using metodaWytworcza.apc;

namespace metodaWytworcza
{
    public abstract class fabryka
    {
        protected abstract Ipojazd buduj(string nazwa);

        public Ipojazd stwoz(string nazwa)
        {
            Ipojazd pojazd = buduj(nazwa);
            return pojazd;
        }
    }
}
