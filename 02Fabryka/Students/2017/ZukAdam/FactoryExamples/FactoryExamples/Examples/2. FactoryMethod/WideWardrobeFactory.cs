using FactoryExamples.Models;
using FactoryExamples.Models.Furnitures;

namespace FactoryExamples.Examples._2._FactoryMethod
{
    public class WideWardrobeFactory : Factory
    {
        public override Furniture MakeDefault()
        {
            return new WideWardrobe();
        }

        public override Furniture CreateWider()
        {
            var furniture = this.MakeDefault();
            furniture.Width = 18;

            return furniture;
        }
    }
}
