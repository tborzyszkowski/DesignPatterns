using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Product.TV
{
    class Samsung : Televisor
    {
        public Samsung()
        {
            brand = "Samsung";
            model = "UE65NU8042";
            diagonal = 65;
        }
    }
}
