using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.TV
{
    class LG : Televisor
    {
        public LG()
        {
            brand = "LG";
            model = "OLED55C8";
            diagonal = 55;
        }
    }
}
