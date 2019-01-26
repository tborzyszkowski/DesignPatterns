using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WP.Drinks;
using WP.Drinks.Builders;
using WP.Observers;

namespace Tests
{
    public class Observer
    {
        Chief chief;
        Barman barman;

        [SetUp]
        public void SetUp()
        {
            chief = new Chief();
            barman = chief.HireBarman();
        }

        [Test]
        public void ChiefIsNotifiedAboutSoldDrink()
        {
            double income1 = chief.Income;
            Drink drink = barman.MakeDrink(ScrewdriverBuilder.Builder);
            double income2 = chief.Income;

            Assert.That(income1 + drink.Price == income2);
        }
    }
}
