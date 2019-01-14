using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Computer
{
    class SVF : Laptop
    {
        public SVF()
        {
            brand = "Sony";
            model = "SVF1521C6E";
            ram = 4;
            diagonal = 15.5;
        }
    }
}
