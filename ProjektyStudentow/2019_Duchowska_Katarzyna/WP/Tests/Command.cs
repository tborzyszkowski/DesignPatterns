using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WP.Drinks;
using WP.Drinks.Builders;
using WP.Observers;

namespace Tests
{
    public class Command
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
        public void AfterReachingMaxIncomeBarIsClosed()
        {
            double max = chief.MaxIncome;
            double income = 0;

            Assert.True(barman.BarOpen);

            while (income < max)
            {
                Drink drink = barman.MakeDrink(GinTonicBuilder.Builder);
                income += drink.Price;
            }

            Assert.False(barman.BarOpen);
        }
    }
}
