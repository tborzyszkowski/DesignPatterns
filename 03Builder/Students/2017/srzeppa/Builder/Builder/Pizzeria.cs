namespace Builder
{
    public class Pizzeria
    {

        public void Construct(PizzaBuilder pizzaBuilder)
        {
            pizzaBuilder.SetName();
            pizzaBuilder.AddCheese();
            pizzaBuilder.AddHam();
            pizzaBuilder.Bake();
            pizzaBuilder.GetPizza();
        }

    }
}
