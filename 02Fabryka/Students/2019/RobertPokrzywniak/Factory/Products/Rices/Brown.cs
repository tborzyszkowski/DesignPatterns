using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Rices
{
    public class Brown : Rice
    {
        public Brown()
        {
            Brand = Brand.Risana;
            Type = "brown";
            Packaging = Packaging.BOX;
            BoilTime = 30;
            Price = 5;
        }
    }
}
