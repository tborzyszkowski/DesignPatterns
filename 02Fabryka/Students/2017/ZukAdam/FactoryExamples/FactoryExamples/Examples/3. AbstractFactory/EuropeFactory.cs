using FactoryExamples.Models.Furnitures;

namespace FactoryExamples.Examples._3._AbstractFactory
{
    public class EuropeFactory : AbstractFactory
    {
        public override CoffeeTable MakeCoffeeTable()
        {
            return new CoffeeTable
            {
                Name = "European coffee table",
                Width = 1.4
            };
        }

        public override LargeDesk MakeLargeDesk()
        {
            return new LargeDesk
            {
                Name = "European large desk",
                Width = 2.5
            };
        }

        public override WideWardrobe MakeWideWardrobe()
        {
            return new WideWardrobe
            {
                Name = "European wide wardrobe",
                Width = 10
            };
        }
    }
}
