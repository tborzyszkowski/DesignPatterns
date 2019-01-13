using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.TV
{
    class Apple : Televisor
    {
        public Apple()
        {
            brand = "Apple";
            model = "a1469";
            diagonal = 0;
        }
    }
}
