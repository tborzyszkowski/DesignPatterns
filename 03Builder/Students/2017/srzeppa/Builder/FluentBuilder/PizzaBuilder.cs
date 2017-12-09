using FluentBuilder.Models;

namespace FluentBuilder
{
    public abstract class PizzaBuilder
    {
        protected Pizza pizza;

        private Pizza Pizza => pizza;

        public abstract PizzaBuilder SetName(string name);
        public abstract PizzaBuilder AddCheese();
        public abstract PizzaBuilder AddHam();
        public abstract PizzaBuilder Bake();

        public static implicit operator Pizza(PizzaBuilder pizzaBuilder)
        {
            return pizzaBuilder
                .SetName(pizzaBuilder.pizza.Name)
                .AddCheese()
                .AddHam()
                .Bake()
                .Pizza;
        }

    }
}
