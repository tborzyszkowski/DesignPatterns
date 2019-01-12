using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.TV
{
    class HP : Televisor
    {
        public HP()
        {
            brand = "HP";
            model = "PL4272N";
            diagonal = 42;
        }
    }
}
