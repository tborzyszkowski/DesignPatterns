using System;

namespace Builder.CaseWhereFactoryIsBetter.Carbohydrates.Potatoes
{
    class TraditionalPotato : Potato
    {
        public TraditionalPotato()
        {
            Producer = "Kupiec";
            Name = "tradycyjny ziemniak kupiec";
            Type = "tradycyjny ziemniak";
            Weight = 3000;
            Price = 2.3;
        }

        public new void Boil()
        {
            Console.WriteLine("Boiling some traditional potatos");
        }

        public new void Eat()
        {
            Console.WriteLine("Eating traditional potatos now");
        }
    }
}
