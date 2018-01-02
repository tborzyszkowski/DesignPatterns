using FluentBuilder.Models;

namespace FluentBuilder
{
    public class PizzaA : PizzaBuilder
    {

        public PizzaA()
        {
            pizza = new Pizza
            {
                Name = "capricosa"
            };
        }

        public override PizzaBuilder AddCheese()
        {
            pizza.Cheese = false;
            return this;
        }

        public override PizzaBuilder AddHam()
        {
            pizza.Ham = true;
            return this;
        }

        public override PizzaBuilder Bake()
        {
            pizza.Baked = true;
            return this;
        }

        public override PizzaBuilder SetName(string name)
        {
            pizza.Name = name;
            return this;
        }
    }
}
