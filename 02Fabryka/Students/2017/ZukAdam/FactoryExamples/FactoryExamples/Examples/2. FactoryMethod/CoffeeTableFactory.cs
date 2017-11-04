using FactoryExamples.Models;
using FactoryExamples.Models.Furnitures;

namespace FactoryExamples.Examples._2._FactoryMethod
{
    public class CoffeeTableFactory : Factory
    {
        public override Furniture MakeDefault()
        {
            return new CoffeeTable();
        }

        public override Furniture CreateWider()
        {
            var furniture = this.MakeDefault();
            furniture.Width = 8;

            return furniture;
        }
    }
}
