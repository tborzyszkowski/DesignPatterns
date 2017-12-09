using FactoryReflection.Fabryka;
using FactoryReflection.Utils;

namespace FactoryReflection.Animals
{
    internal class Bear : Animal
    {
        public override string Name => "WojteG";
        protected override string Kind => "Bear";
        protected override FurType Fur => FurType.Thick;
    }
}