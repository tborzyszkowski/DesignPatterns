using FluentBuilder.Models;

namespace FluentBuilder
{
    public class PizzaB : PizzaBuilder
    {
        public PizzaB()
        {
            pizza = new Pizza
            {
                Name = "italiana"
            };
        }

        public override PizzaBuilder AddCheese()
        {
            pizza.Cheese = true;
            return this;
        }

        public override PizzaBuilder AddHam()
        {
            pizza.Ham = false;
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
