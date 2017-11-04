using FactoryGenerionMethod.Fabryka;
using FactoryGenerionMethod.Utils;

namespace FactoryGenerionMethod.Animals
{
    internal class Cat : Animal
    {
        public override string Name => "Dracula";
        protected override string Kind => "Koteł";
        protected override FurType Fur => FurType.Thin;

        public Cat()
        {
        }

        public override string ToString()
        {
            return $"Name : {Name} \n Kind : {Kind} \n FurType : {Fur}";
        }
    }
}