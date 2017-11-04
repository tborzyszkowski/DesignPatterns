using FactoryGenerionMethod.Fabryka;
using FactoryGenerionMethod.Utils;

namespace FactoryGenerionMethod.Animals
{
    internal class Bear : Animal
    {
        public Bear()
        {
        }

        public override string Name => "WojteG";
        protected override string Kind => "Bear";
        protected override FurType Fur => FurType.Thick;

        public override string ToString()
        {
            return $"Name : {Name} \n Kind : {Kind} \n FurType : {Fur}";
        }
    }
}