using FactoryAbstract.Fabryka;
using FactoryAbstract.Utils;

namespace FactoryAbstract.Animals
{
    internal class Hedgehog : Animal
    {
        public Hedgehog()
        {
        }

        public override string Name => "Hendehoh";
        protected override string Kind => "Hedgehog";
        protected override FurType Fur => FurType.Rought;

        public override string ToString()
        {
            return $"Name : {Name} \n Kind : {Kind} \n FurType : {Fur}";
        }
    }
}