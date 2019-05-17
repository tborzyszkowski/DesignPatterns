using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaProsta.bwp
{
    public abstract class bwp
    {
        protected String nazwa;
        protected decimal kaliber;
        protected int mocSilnika;


        public String dajNazwe()
        {
            return nazwa;
        }

        public decimal dajKaliber()
        {
            return kaliber;
        }

        public int dajMocSilnika()
        {
            return mocSilnika;
        }
    }
}
