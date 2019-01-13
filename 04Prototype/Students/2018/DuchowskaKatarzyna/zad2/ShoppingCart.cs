using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.zad2
{
    [Serializable()]
    public class ShoppingCart : Prototype<ShoppingCart>
    {
        public List<Product> Products { get; set; }

        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        public ShoppingCart(List<Product> products)
        {
            Products = products;
        }

        public void AddToCart(Product product)
        {
            Products.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            Products.Remove(product);
        }
    }
}
