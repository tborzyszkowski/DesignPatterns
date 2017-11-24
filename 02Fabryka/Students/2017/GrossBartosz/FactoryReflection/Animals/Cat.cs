using FactoryReflection.Fabryka;
using FactoryReflection.Utils;

namespace FactoryReflection.Animals
{
    internal class Cat : Animal
    {
        public override string Name => "Dracula";
        protected override string Kind => "Koteł";
        protected override FurType Fur => FurType.Thin;

        public Cat()
        {
        }
    }
}
