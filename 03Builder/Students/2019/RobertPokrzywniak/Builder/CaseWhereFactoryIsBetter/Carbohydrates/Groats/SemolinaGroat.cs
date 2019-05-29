using System;

namespace Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats
{
    class SemolinaGroat : Groat
    {
        public SemolinaGroat()
        {
            Producer = "Kupiec";
            Name = "kasza manna kupiec";
            Type = "kasza manna";
            Weight = 300;
            Price = 1.3;
        }

        public new void Boil()
        {
            Console.WriteLine("Boiling some semolina groats");
        }

        public new void Eat()
        {
            Console.WriteLine("Eating semolina groats now");
        }
    }
}
