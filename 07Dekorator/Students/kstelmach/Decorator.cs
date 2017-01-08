using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator
{
   abstract class Decorator : ShopItem
    {
        protected ShopItem shopItem;

        // Constructor
        public Decorator(ShopItem shopItem)
        {
            this.shopItem = shopItem;
        }

        public override void Display()
        {
            shopItem.Display();
        }
    }
}
