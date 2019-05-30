using System;

namespace Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats
{
    public abstract class Groat : ICarbohydrate
    {
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }

        public void Boil()
        {
            Console.WriteLine("Boiling some groats");
        }
        public void Eat()
        {
            Console.WriteLine("Eating groats now");
        }
    }
}
