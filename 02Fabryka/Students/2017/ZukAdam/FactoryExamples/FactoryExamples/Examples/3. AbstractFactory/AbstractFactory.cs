using FactoryExamples.Models.Furnitures;

namespace FactoryExamples.Examples._3._AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract CoffeeTable MakeCoffeeTable();

        public abstract LargeDesk MakeLargeDesk();

        public abstract WideWardrobe MakeWideWardrobe();
    }
}
