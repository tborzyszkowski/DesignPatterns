using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.zad2
{
    [Serializable()]
    public class Product
    {
        public String Name { get; set; }
        public Price Price { get; set; }

        public Product(String name, double price)
        {
            Name = name;
            Price = new Price(price);
        }
    }
}
