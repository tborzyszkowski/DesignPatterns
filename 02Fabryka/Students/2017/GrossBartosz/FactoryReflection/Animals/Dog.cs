using FactoryReflection.Fabryka;
using FactoryReflection.Utils;

namespace FactoryReflection.Animals
{
    internal class Dog : Animal
    {
        public override string Name => "Janusz";
        protected override string Kind => "Dog";
        protected override FurType Fur => FurType.Shiny;
    }
}
