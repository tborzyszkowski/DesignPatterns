using System;
using FluentAssertions;
using FluentBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderTests
{
    [TestClass]
    public class FluentBuilderTests
    {

        [TestMethod]
        public void FluentBuilderInstancesTests()
        {
            var pizzeria = new Pizzeria();

            var pizzaA = pizzeria.Construct(new PizzaA());
            var pizzaB = pizzeria.Construct(new PizzaB());

            pizzaA.GetPizza().Should().Be("capricosa Cheese: False Ham: True Baked: True");
            pizzaB.GetPizza().Should().Be("italiana Cheese: True Ham: False Baked: True");
        }

    }
}
