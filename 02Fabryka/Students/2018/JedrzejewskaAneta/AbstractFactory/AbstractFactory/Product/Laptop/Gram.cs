using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Computer
{
    class Gram : Laptop
    {
        public Gram()
        {
            brand = "LG";
            model = "Gram 14Z970-U.AP51U1";
            ram = 8;
            diagonal = 14;
        }
    }
}
