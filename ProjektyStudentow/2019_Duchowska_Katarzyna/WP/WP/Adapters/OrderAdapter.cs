using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Drinks;
using WP.Drinks.Builders;

namespace WP.Adapters
{
    public class OrderAdapter
    {
        public Func<Drink> OrderDrink;
        Barman Barman;

        private Dictionary<String, (String, String)> Menu = new Dictionary<String, (String, String)>
        {
            { "Screwdriver", ("Vodka", "Juice") },
            { "CubaLibre", ("Rum", "Cola") },
            { "GinTonic", ("Gin", "Tonic") }
        };

        public OrderAdapter(Barman barman, CardFromWaiter card)
        {
            Barman = barman;
            OrderDrink = () =>
            {
                String alcoholName = card.Card["Alcohol"];
                String softName = card.Card["Soft"];

                return FindDrink(alcoholName, softName);
            };
        }

        public OrderAdapter(Barman barman, Waiter waiter)
        {
            Barman = barman;
            OrderDrink = () =>
            {
                (String, String) order = waiter.GetOrder();

                return FindDrink(order.Item1, order.Item2);
            };
        }

        public OrderAdapter(Barman barman, TelephoneOrder order)
        {
            Barman = barman;
            OrderDrink = () =>
            {
                return FindDrink(Menu[order.DrinkName].Item1, Menu[order.DrinkName].Item2);
            };
        }


        private Drink FindDrink(String alcoholName, String softName)
        {
            if (alcoholName == "Gin" && softName == "Tonic")
                return Barman.MakeDrink(GinTonicBuilder.Builder);

            if (alcoholName == "Vodka" && softName == "Juice")
                return Barman.MakeDrink(ScrewdriverBuilder.Builder);

            if (alcoholName == "Rum" && softName == "Cola")
                return Barman.MakeDrink(CubaLibreBuilder.Builder);

            throw new Exception("NoSuchDrinkException");
        }
    }
}
