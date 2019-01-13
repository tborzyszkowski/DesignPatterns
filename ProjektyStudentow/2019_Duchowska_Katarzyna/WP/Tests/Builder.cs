using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WP.Drinks;
using WP.Drinks.Alcohols;
using WP.Drinks.Builders;
using WP.Drinks.Softs;
using WP.Observers;

namespace Tests
{
    public class Builder
    {
        Barman barmanUnderTest;

        [SetUp]
        public void SetUp()
        {
            Chief chief = new Chief();
            barmanUnderTest = chief.HireBarman();
        }

        [Test]
        public void MakeCubaLibre()
        {
            Drink drink = barmanUnderTest.MakeDrink(CubaLibreBuilder.Builder);

            Assert.That(drink.Alcohol.GetType() == typeof(Rum) &&
                        drink.Soft.GetType() == typeof(Cola));
        }

        [Test]
        public void MakeGinTonic()
        {
            Drink drink = barmanUnderTest.MakeDrink(GinTonicBuilder.Builder);

            Assert.That(drink.Alcohol.GetType() == typeof(Gin) &&
                        drink.Soft.GetType() == typeof(Tonic));
        }

        [Test]
        public void MakeScrewdriver()
        {
            Drink drink = barmanUnderTest.MakeDrink(ScrewdriverBuilder.Builder);

            Assert.That(drink.Alcohol.GetType() == typeof(Vodka) &&
                        drink.Soft.GetType() == typeof(Juice));
        }
    }
}
