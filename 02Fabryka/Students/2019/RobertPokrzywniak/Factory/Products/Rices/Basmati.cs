using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Rices
{
    public class Basmati : Rice
    {
        public Basmati()
        {
            Brand = Brand.Halina;
            Type = "basmati";
            Packaging = Packaging.BOX;
            BoilTime = 15;
            Price = 3;
        }
    }
}
