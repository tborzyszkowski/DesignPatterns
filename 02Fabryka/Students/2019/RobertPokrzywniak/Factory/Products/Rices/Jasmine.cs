using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Rices
{
    public class Jasmine : Rice
    {
        public Jasmine()
        {
            Brand = Brand.Sonko;
            Type = "jasmine";
            Packaging = Packaging.BOX;
            BoilTime = 16;
            Price = 2;
        }
    }
}
