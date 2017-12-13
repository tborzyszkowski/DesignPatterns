using FactoryExamples.Models;
using FactoryExamples.Models.Furnitures;
using System;

namespace FactoryExamples.Examples._1._SimpleFactory
{
    public class SimpleFurnitureFactory
    {
        public Furniture CreateFurniture(string type)
        {
            switch (type)
            {
                case "LargeDesk":
                    return new LargeDesk();
                case "CoffeeTable":
                    return new CoffeeTable();
                case "WideWardrobe":
                    return new WideWardrobe();
                default:
                    throw new Exception("Incorrect type value.");
            }
        }
    }
}
