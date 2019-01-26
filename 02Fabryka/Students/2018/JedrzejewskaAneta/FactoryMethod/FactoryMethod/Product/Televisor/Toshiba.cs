using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Product.TV
{
    class Toshiba : Televisor
    {
        public Toshiba()
        {
            brand = "Toshiba";
            model = "48L3663DG";
            diagonal = 48;
            isSmartTV = true;
        }
    }
}
