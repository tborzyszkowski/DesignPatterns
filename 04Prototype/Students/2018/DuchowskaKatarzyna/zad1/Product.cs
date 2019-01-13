using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.zad1
{
    public class Product : IPrototype
    {
        public String Name { get; set; }
        public int Price { get; set; }
        public String Currency { get; set; }

        public Product(String name, int price)
        {
            Name = name;
            Price = price;
            Currency = "PLN";
        }

        //shallow copy
        public IPrototype ShallowCopy()
        {
            return MemberwiseClone() as IPrototype;
        }

        //deep copy - same as shallow
        public IPrototype DeepCopy()
        {
            return ShallowCopy();
        }
    }
}
