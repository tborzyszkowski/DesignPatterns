using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Drinks.Alcohols
{
   public class Vodka : Alcohol
    {
        public Vodka() : base()
        {
            ABV = 40;
            Country = "Poland";
        }
    }
}
