using System;

namespace Builder.CaseWhereFactoryIsBetter.Carbohydrates.Potatoes
{
    public abstract class Potato : ICarbohydrate
    {
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }

        public void Boil()
        {
            Console.WriteLine("Boiling some potatoes");
        }
        public void Eat()
        {
            Console.WriteLine("Eating potatoes now");
        }
    }
}
