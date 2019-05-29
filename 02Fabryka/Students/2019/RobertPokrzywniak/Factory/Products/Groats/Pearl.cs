using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Groats
{
    public class Pearl : Groat
    {
        public Pearl()
        {
            Brand = Brand.Halina;
            Type = "pearl";
            BoilTime = 11;
            Price = 6;
            Weight = 440;
        }
    }
}
