using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product.Computer
{
    class Vostro : Laptop
    {
        public Vostro()
        {
            brand = "Dell";
            model = "Vostro 3568";
            ram = 4;
            diagonal = 15.6;
        }
    }
}
