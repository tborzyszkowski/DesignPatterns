using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Drinks.Softs
{
    public class Tonic : Soft
    {
        public Tonic() : base()
        {
            Flavour = "Tonic";
            Fizzy = true;
        }
    }
}
