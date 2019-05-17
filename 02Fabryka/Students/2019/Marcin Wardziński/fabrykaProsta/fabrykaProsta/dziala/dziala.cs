using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaProsta.dziala
{
    public abstract class dziala
    {
        protected String nazwa;
        protected decimal kaliber;
        protected int zaloga;


        public String dajNazwe()
        {
            return nazwa;
        }

        public decimal dajKaliber()
        {
            return kaliber;
        }

        public int dajZaloge()
        {
            return zaloga;
        }
    }
}
