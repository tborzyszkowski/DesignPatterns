using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product.TV
{
    class Sharp : Televisor
    {

        public Sharp()
        {
            brand = "Sharp";
            model = "LED LC-40CFE6242E";
            diagonal = 40;
            isSmartTV = true;
        }
    }
}
