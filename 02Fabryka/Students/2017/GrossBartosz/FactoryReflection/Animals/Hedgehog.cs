using FactoryReflection.Fabryka;
using FactoryReflection.Utils;

namespace FactoryReflection.Animals
{
    internal class Hedgehog : Animal
    {
        public override string Name => "Hendehoh";
        protected override string Kind => "Hedgehog";
        protected override FurType Fur => FurType.Rought;
    }
}