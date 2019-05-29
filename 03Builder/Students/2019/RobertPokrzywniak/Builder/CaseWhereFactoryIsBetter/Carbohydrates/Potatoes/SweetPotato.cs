using System;

namespace Builder.CaseWhereFactoryIsBetter.Carbohydrates.Potatoes
{
    class SweetPotato : Potato
    {
        public SweetPotato()
        {
            Producer = "Sonko";
            Name = "słodki ziemniak sonko";
            Type = "słodki ziemniak";
            Weight = 2000;
            Price = 7.6;
        }

        public new void Boil()
        {
            Console.WriteLine("Boiling some sweet potatos");
        }

        public new void Eat()
        {
            Console.WriteLine("Eating sweet potatos now");
        }
    }
}
