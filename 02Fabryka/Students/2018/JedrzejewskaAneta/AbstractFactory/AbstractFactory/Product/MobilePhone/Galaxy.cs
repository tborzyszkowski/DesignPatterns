using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Smartphone
{
    class Galaxy : MobilePhone
    {
        public Galaxy()
        {
            brand = "Samsung";
            model = "Galaxy Note 9";
            year = 2018;
            diagonal = 6.4;
        }
    }
}
