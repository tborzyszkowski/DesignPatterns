using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.TV
{
    class Sony : Televisor
    {

        public Sony()
        {
            brand = "Sony";
            model = "W70C";
            diagonal = 40;
        }
    }
}
