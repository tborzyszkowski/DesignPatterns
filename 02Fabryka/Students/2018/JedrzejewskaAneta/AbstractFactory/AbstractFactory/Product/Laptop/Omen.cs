using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Product.Computer
{
    class Omen : Laptop
    {
        public Omen()
        {
            brand = "HP";
            model = "Omen 15-ce010nw";
            ram = 8;
            diagonal = 15.6;
        }
    }
}
