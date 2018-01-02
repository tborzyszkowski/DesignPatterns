using WzorceFactory.Fabryka;
using WzorceFactory.Utils;

namespace WzorceFactory.Animals
{
    public class Dog : Animal
    {
        public Dog()
        {
        }

        public override string Name => "Janusz";
        protected override string Kind => "Dog";
        protected override FurType Fur => FurType.Shiny;

        public override string ToString()
        {
            return $"Name : {Name} \n Kind : {Kind} \n FurType : {Fur}";
        }
    }
}