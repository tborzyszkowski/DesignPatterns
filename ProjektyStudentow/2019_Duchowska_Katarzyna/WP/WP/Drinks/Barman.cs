using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Drinks.Builders;
using WP.Observers;
using WP.Commands;

namespace WP.Drinks
{
    public class Barman : Subject, IReceiver
    {
        public volatile bool BarOpen = true;

        public Barman(Observer chief) : base()
        {
            observers.Add(chief);
        }

        public void Action()
        {
            Console.WriteLine("Bar closed!");
            BarOpen = false;
        }

        public Drink MakeDrink(DrinkBuilder builder)
        {
            if (!BarOpen)
            {
                return null;
            }

            Drink drink = DrinkBuilder.GetDrink(builder);
            Notify(drink.Price);
            return drink;
        }
    }
}
