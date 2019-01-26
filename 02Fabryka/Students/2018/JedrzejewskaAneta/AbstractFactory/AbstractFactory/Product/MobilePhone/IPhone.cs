using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Smartphone
{
    class IPhone : MobilePhone
    {
        public IPhone()
        {
            brand = "Apple";
            model = "IPhone 8";
            year = 2078;
            diagonal = 4.7;
        }
    }
}
