using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Groats
{
    public class Semolina : Groat
    {
        public Semolina()
        {
            Brand = Brand.Britta;
            Type = "semolina";
            BoilTime = 12;
            Price = 8;
            Weight = 510;
        }
    }
}
