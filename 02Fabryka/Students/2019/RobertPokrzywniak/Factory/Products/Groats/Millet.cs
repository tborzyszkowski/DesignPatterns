using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Groats
{
    public class Millet : Groat
    {
        public Millet()
        {
            Brand = Brand.Risana;
            Type = "millet";
            BoilTime = 17;
            Price = 4;
            Weight = 450;
        }
    }
}
