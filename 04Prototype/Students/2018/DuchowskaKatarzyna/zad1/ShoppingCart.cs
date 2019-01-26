using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.zad1
{
    public class ShoppingCart : IPrototype
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

        //shallow copy
        public IPrototype ShallowCopy()
        {
            return this.MemberwiseClone() as IPrototype;
        }

        //deep copy
        public IPrototype DeepCopy()
        {
            ShoppingCart cart = new ShoppingCart();
            Products.ForEach(product => cart.AddToCart(product.ShallowCopy() as Product));
            return cart as IPrototype;
        }
    }
}
