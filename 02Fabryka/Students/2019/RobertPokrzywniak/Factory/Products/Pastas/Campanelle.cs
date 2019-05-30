using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Pastas
{
    public class Campanelle : Pasta
    {
        public Campanelle()
        {
            Brand = Brand.Britta;
            Type = "campanelle";
            BoilTime = 17;
            Price = 1;
        }
    }
}
