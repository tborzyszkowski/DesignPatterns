using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product.TV
{
    class Panasonic : Televisor
    {
        public Panasonic()
        {
            brand = "Panasonic";
            model = "LED TX-55EX610E";
            diagonal = 55;
            isSmartTV = true;
        }
    }
}
