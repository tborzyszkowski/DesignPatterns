using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class SimpleFactory
    {
        public Pizza createProduct(string typ)
        {
            var pizza = new Pizza();
            if (typ == "Pizza 1")
            {
                pizza = new Pizza1();
            }
            else if (typ == "Pizza 2")
            {
                pizza = new Pizza2();
            }

            return pizza;
        }
    }
}
