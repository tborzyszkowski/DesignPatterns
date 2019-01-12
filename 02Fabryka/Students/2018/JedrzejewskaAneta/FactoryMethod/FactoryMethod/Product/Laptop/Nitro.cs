using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product.Computer
{
    class Nitro : Laptop
    {
        public Nitro()
        {
            brand = "Acer";
            model = "Nitro 5";
            ram = 5;
            diagonal = 15.6;
        }
    }
}
