using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Drinks.Softs
{
    public class Juice : Soft
    {
        public Juice(String flavour) : base()
        {
            Flavour = flavour;
            Fizzy = false;
        }
    }
}
