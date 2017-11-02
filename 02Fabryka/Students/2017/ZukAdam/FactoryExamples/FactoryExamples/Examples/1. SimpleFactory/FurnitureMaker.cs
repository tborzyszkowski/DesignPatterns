using FactoryExamples.Models;

namespace FactoryExamples.Examples._1._SimpleFactory
{
    public class FurnitureMaker
    {
        public static SimpleFurnitureFactory Factory { get; set; }

        public static Furniture Make(string type)
        {
            var furniture = Factory.CreateFurniture(type);

            furniture.CreateParts();
            furniture.Pack();

            return furniture;
        }
    }
}
