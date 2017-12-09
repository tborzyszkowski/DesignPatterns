using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class SimpleFactory
    {
        public Product createProduct(String type)
        {
            var product = new Product();
            if (type == "A")
            {
                product = new ProductA();
            }
            else if (type == "B")
            {
                product = new ProductB();
            }

            return product;
        }
    }
}
