using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Groats
{
    public class BuckWheat : Groat
    {
        public BuckWheat()
        {
            Brand = Brand.Sonko;
            Type = "buckwheat";
            BoilTime = 14;
            Price = 6;
            Weight = 500;
        }
    }
}
