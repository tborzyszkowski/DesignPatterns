using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WP.Adapters;
using WP.Drinks;
using WP.Drinks.Alcohols;
using WP.Drinks.Softs;
using WP.Observers;

namespace Tests
{
    public class Adapter
    {
        Barman barman;
        OrderAdapter adapterUnderTest;

        [SetUp]
        public void SetUp()
        {
            Chief chief = new Chief();
            barman = chief.HireBarman();
        }

        [Test]
        public void OrderFromCard()
        {
            adapterUnderTest = new OrderAdapter(barman, new CardFromWaiter(new List<string>() { "Rum", "Cola" }));
            Drink drink = adapterUnderTest.OrderDrink();
            
            Assert.That(drink.Alcohol.GetType() == typeof(Rum) &&
                        drink.Soft.GetType() == typeof(Cola));
        }

        [Test]
        public void OrderFromTelephone()
        {
            adapterUnderTest = new OrderAdapter(barman, new TelephoneOrder("Screwdriver"));
            Drink drink = adapterUnderTest.OrderDrink();

            Assert.That(drink.Alcohol.GetType() == typeof(Vodka) &&
                        drink.Soft.GetType() == typeof(Juice));
        }

        [Test]
        public void OrderFromWaiter()
        {
            adapterUnderTest = new OrderAdapter(barman, new Waiter());
            Drink drink = adapterUnderTest.OrderDrink();

            Assert.IsNotNull(drink);
        }
    }
}
