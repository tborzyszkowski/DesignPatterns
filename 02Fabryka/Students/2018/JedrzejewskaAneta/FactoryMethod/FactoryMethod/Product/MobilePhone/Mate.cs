using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product.Smartphone
{
    class Mate : MobilePhone
    {
        public Mate()
        {
            brand = "Huawei";
            model = "Mate 10 Pro";
            year = 2017;
            diagonal = 6;
        }
    }
}
