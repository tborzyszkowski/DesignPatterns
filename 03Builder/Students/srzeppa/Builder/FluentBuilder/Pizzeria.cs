using FluentBuilder.Models;

namespace FluentBuilder
{
    public class Pizzeria
    {

        public Pizza Construct(PizzaBuilder pizzaBuilder)
        {
            return pizzaBuilder;
        }

    }
}
