using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator
{
    class SellAble : Decorator
    {
        protected List<string> sellers = new List<string>();

        // Constructor
        public SellAble(ShopItem shopItem)
          : base(shopItem) {
        }

        public void SellItem(string model)
        {
            sellers.Add(model);
            shopItem.Copies--;
        }

        public void ReturnItem(string model)
        {
            sellers.Remove(model);
            shopItem.Copies++;
        }

        public override void Display()
        {
            base.Display();

            foreach (string seller in sellers)
            {
                Console.WriteLine(" sellerr: " + seller);
            }
        }
    }
}
