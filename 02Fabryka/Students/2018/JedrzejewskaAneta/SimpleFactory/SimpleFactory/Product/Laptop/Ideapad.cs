using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory.Product.Computer
{
    class Ideapad : Laptop
    {
        public Ideapad()
        {
            brand = "Lenovo";
            model = "Ideapad 330-15IKBR";
            ram = 8;
            diagonal = 15.6;
        }
    }
}
