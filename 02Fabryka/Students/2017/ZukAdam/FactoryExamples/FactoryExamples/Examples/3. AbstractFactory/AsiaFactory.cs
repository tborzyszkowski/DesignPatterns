using FactoryExamples.Models.Furnitures;

namespace FactoryExamples.Examples._3._AbstractFactory
{
    public class AsiaFactory : AbstractFactory
    {
        public override CoffeeTable MakeCoffeeTable()
        {
            return new CoffeeTable
            {
                Name = "Asian coffee table",
                Width = 1
            };
        }

        public override LargeDesk MakeLargeDesk()
        {
            return new LargeDesk
            {
                Name = "Asian large desk",
                Width = 1.5
            };
        }

        public override WideWardrobe MakeWideWardrobe()
        {
            return new WideWardrobe
            {
                Name = "Asian wide wardrobe",
                Width = 3
            };
        }
    }
}