using System;

namespace NestedDeepCopy
{
    [Serializable]
    public class Toy
    {
        public string Name;
        public decimal Price;

        public Toy(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
