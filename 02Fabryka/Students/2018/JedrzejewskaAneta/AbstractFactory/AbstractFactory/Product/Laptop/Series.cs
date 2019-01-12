using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Computer
{
    class Series : Laptop
    {
        public Series()
        {
            brand = "Samsung";
            model = "Series 3";
            ram = 4;
            diagonal = 15.6;
        }
    }
}
