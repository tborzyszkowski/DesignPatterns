using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Smartphone
{
    class Xperia : MobilePhone
    {
        public Xperia()
        {
            brand = "Sony";
            model = "Xperia XZ3";
            year = 2018;
            diagonal = 6;
        }
    }
}
