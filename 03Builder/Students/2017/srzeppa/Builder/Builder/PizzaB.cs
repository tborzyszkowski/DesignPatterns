using Builder.Models;

namespace Builder
{
    public class PizzaB : PizzaBuilder
    {
        public PizzaB()
        {
            Pizza = new Pizza();
        }

        public override void AddCheese()
        {
            Pizza.Cheese = true;
        }

        public override void AddHam()
        {
            Pizza.Ham = false;
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
            Pizza.Name = "Italiana";
        }
    }
}
