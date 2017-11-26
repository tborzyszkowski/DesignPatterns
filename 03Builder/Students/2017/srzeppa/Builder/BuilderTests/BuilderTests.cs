using Builder;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderTests
{
    [TestClass]
    public class BuilderTests
    {

        [TestMethod]
        public void BuilderInstancesTests()
        {
            var pizzeria = new Pizzeria();

            var pizzaA = new PizzaA();
            pizzeria.Construct(pizzaA);

            var pizzaB = new PizzaB();
            pizzeria.Construct(pizzaB);
            
            pizzaA.Should().BeOfType<PizzaA>();
            pizzaB.Should().BeOfType<PizzaB>();

            var capricosa = pizzaA.GetPizza();
            var italiana = pizzaB.GetPizza();

            capricosa.Should().Be("Capricosa cheese: False ham: True");
            italiana.Should().Be("Italiana cheese: True ham: False");
        }

    }
}
