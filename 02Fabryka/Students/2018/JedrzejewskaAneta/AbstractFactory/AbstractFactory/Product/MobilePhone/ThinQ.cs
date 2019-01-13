using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Smartphone
{
    class ThinQ : MobilePhone
    {
        public ThinQ()
        {
            brand = "LG";
            model = "G7";
            year = 2018;
            diagonal = 6.1;
        }
    }
}
