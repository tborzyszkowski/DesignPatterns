using Builder.Models;

namespace Builder
{
    public class PizzaA : PizzaBuilder
    {

        public PizzaA()
        {
            Pizza = new Pizza();
        }

        public override void AddCheese()
        {
            Pizza.Cheese = false;
        }

        public override void AddHam()
        {
            Pizza.Ham = true;
        }

        public override void Bake()
        {
            Pizza.Baked = true;
        }

        public override string GetPizza()
        {
            return $"{Pizza.Name} cheese: {Pizza.Cheese} ham: {Pizza.Ham}";
        }

        public override void SetName()
        {
            Pizza.Name = "Capricosa";
        }
    }
}
