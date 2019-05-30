using System;

namespace Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats
{
    class BuckwheatGroat : Groat
    {
        public BuckwheatGroat()
        {
            Producer = "Halina";
            Name = "kasza gryczana Halina";
            Type = "kasza gryczana";
            Weight = 500;
            Price = 3.7;
        }

        public new void Boil()
        {
            Console.WriteLine("Boiling some buckwheat groats");
        }

        public new void Eat()
        {
            Console.WriteLine("Eating buckwheat groats now");
        }
    }
}
