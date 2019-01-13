using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Product.TV
{
    class Sharp : Televisor
    {

        public Sharp()
        {
            brand = "Sharp";
            model = "LED LC-40CFE6242E";
            diagonal = 40;
        }
    }
}
