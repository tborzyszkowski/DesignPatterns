using FactoryExamples.Models;
using FactoryExamples.Models.Furnitures;

namespace FactoryExamples.Examples._2._FactoryMethod
{
    public class LargeDeskFactory : Factory
    {
        public override Furniture MakeDefault()
        {
            return new LargeDesk();
        }

        public override Furniture CreateWider()
        {
            var furniture = this.MakeDefault();
            furniture.Width = 15;

            return furniture;
        }
    }
}
