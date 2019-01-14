using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Drinks.Alcohols
{
    public abstract class Alcohol
    {
        public double ABV { get; set; }
        public String Country { get; set; }
    }
}
