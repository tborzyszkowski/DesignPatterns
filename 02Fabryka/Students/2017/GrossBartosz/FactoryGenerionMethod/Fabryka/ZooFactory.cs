using System;
using FactoryGenerionMethod.Animals;

namespace FactoryGenerionMethod.Fabryka
{
    internal abstract class ZooFactory
    {
        public abstract Animal CreateAnimal(string type);
    }


    internal class ZooFactoryA : ZooFactory
    {
        public override Animal CreateAnimal(string type)
        {
            if (type.Equals("Hedgehog"))
            {
                return new Hedgehog();
            }
            return type.Equals("Dog") ? new Dog() : null;
        }
    }

    internal class ZooFactoryB : ZooFactory
    {
        public override Animal CreateAnimal(string type)
        {
            if (type.Equals("Cat"))
            {
                return new Cat();
            }
            return type.Equals("Bear") ? new Bear() : null;
        }
    }

}
