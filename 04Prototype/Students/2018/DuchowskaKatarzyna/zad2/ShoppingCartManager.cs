using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.zad2
{
    public class ShoppingCartManager
    {
        Dictionary<String, ShoppingCart> Carts = new Dictionary<String, ShoppingCart>();

        public void Add(String key, ShoppingCart cart)
        {
            Carts.Add(key, cart);
        }

        public ShoppingCart Get(String key)
        {
            return Carts[key];
        }
    }
}
