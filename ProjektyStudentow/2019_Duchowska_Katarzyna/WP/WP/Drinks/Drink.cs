using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Drinks.Alcohols;
using WP.Drinks.Softs;

namespace WP.Drinks
{
   public class Drink
    {
        public double Price { get; set; }
        public Alcohol Alcohol { get; set; }
        public Soft Soft { get; set; }
        public bool WithIce { get; set; }

        public Drink()
        {
            Price = new Random().NextDouble() * 100 + 1;
        }

        public virtual void Decorate()
        {
            WithIce = true;
        }
    }
}
