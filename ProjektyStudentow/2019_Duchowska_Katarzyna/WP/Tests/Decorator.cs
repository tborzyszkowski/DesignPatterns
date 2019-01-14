using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WP.Drinks;
using WP.Drinks.Builders;
using WP.Observers;

namespace Tests
{
    public class Decorator
    {
        Barman barman;

        [SetUp]
        public void SetUp()
        {
            Chief chief = new Chief();
            barman = chief.HireBarman();
        }

        [Test]
        public void DrinkDecoratorAddsIce()
        {
            Drink drink = barman.MakeDrink(ScrewdriverBuilder.Builder);
            DrinkDecorator decoratedDrink = new DrinkDecorator(drink);
            decoratedDrink.Decorate();

            Assert.That(decoratedDrink.WithIce);
        }
        
        [Test]
        public void DrinkDecoratorMakesItMoreExpensive()
        {
            Drink drink = barman.MakeDrink(ScrewdriverBuilder.Builder);
            double initialPrice = drink.Price;

            DrinkDecorator decorator = new DrinkDecorator(drink);
            decorator.Decorate();
            double finalPrice = drink.Price;

            Assert.That(initialPrice + 50 == finalPrice);
        }
    }
}
