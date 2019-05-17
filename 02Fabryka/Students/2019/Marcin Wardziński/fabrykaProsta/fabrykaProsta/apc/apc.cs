using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaProsta.apc
{
    public abstract class apc
    {
        protected String nazwa;
        protected decimal kaliber;
        protected int desant;


        public String dajNazwe()
        {
            return nazwa;
        }

        public decimal dajKaliber()
        {
            return kaliber;
        }

        public int dajDesant()
        {
            return desant;
        }
    }
}
