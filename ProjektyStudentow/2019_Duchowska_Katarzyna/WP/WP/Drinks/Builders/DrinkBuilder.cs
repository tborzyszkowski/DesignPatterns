using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Drinks.Alcohols;
using WP.Drinks.Softs;

namespace WP.Drinks.Builders
{
    public abstract class DrinkBuilder
    {
        protected Drink Drink { get; set; }

        public DrinkBuilder()
        {
            Drink = new Drink();
        }

        public abstract DrinkBuilder WithAlcohol();
        public abstract DrinkBuilder WithSoft();

        public static Drink GetDrink(DrinkBuilder db)
        {
            return db.WithAlcohol()
                     .WithSoft()
                     .Drink;
        }

    }
}
