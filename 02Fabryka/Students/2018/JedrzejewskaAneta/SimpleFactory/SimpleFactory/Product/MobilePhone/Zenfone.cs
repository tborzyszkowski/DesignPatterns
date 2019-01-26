using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Product.Smartphone
{
    class Zenfone : MobilePhone
    {
        public Zenfone()
        {
            brand = "Asus";
            model = "Zenfone 5Z";
            year = 2018;
            diagonal = 6.3;
        }
    }
}
