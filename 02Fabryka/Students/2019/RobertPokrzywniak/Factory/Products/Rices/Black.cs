using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products.Rices
{
    public class Black : Rice
    {
        public Black()
        {
            Brand = Brand.Britta;
            Type = "britta";
            Packaging = Packaging.SACHET;
            BoilTime = 14;
            Price = 4;
        }
    }
}
