using System;

namespace Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats
{
    public class MilletGroat : Groat
    {
        public MilletGroat()
        {
            Producer = "Sonko";
            Name = "kasza jaglana Sonko";
            Type = "kasza jaglana";
            Weight = 450;
            Price = 5.6;
        }

        public new void Boil()
        {
            Console.WriteLine("Boiling some millet groats");
        }
        public new void Eat()
        {
            Console.WriteLine("Eating millet groats now");
        }
    }
}
