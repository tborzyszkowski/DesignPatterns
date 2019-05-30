using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Pastas
{
    public class Farfalle : Pasta
    {
        public Farfalle()
        {
            Brand = Brand.Sonko;
            Type = "farfalle";
            BoilTime = 31;
            Price = 7;
        }
    }
}
