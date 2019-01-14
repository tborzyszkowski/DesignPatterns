using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Drinks
{
    public class DrinkDecorator : Drink
    {
        public Drink Drink { get; set; }

        public DrinkDecorator(Drink drink) : base()
        {
            Drink = drink;
        }

        public override void Decorate()
        {
            base.Decorate();
            Drink.Price += 50;
        }
    }
}
