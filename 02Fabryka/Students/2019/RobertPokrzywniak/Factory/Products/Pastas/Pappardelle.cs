using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Pastas
{
    public class Pappardelle : Pasta
    {
        public Pappardelle()
        {
            Brand = Brand.Halina;
            Type = "pappardelle";
            BoilTime = 15;
            Price = 3;
        }
    }
}
