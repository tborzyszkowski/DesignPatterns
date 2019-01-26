using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Smartphone
{
    class Elite : MobilePhone
    {
        public Elite()
        {
            brand = "HP";
            model = "Elite X3";
            year = 2017;
            diagonal = 5.96;
        }
    }
}
