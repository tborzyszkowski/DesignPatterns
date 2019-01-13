using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Product.Smartphone
{
    class Pixel : MobilePhone
    {
        public Pixel()
        {
            brand = "Google";
            model = "Pixel 2 XL";
            year = 2018;
            diagonal = 6;
        }
    }
}
