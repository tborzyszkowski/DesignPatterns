using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaProsta.czolg
{
    public abstract class czolg
    {
        protected String nazwa;
        protected decimal kaliber;
        protected int pancerz;
        protected int predkosc;

        public String dajNazwe()
        {
            return nazwa;
        }

        public decimal dajKaliber()
        {
            return kaliber;
        }

        public int dajPancerz()
        {
            return predkosc;
        }

        public int dajPredkosc()
        {
            return predkosc;
        }
    }
}
