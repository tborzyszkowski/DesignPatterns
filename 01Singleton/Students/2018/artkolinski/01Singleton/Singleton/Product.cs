using System;

namespace Singleton
{
    [Serializable]
    public class Product
    {
        public string Name;
        public int Price;
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
