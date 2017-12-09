using System;
using System.Reflection;
using FactoryAbstract.Animals;

namespace FactoryAbstract.Fabryka
{
    internal abstract class ZooFactory
    {
        public abstract Animal FactoryMethod();
    }


    internal class ZooFactoryA : ZooFactory
    {
        public override Animal FactoryMethod()
        {
            return Activator.CreateInstance<Hedgehog>();
        }
    }

    internal class ZooFactoryB : ZooFactory
    {
        public override Animal FactoryMethod()
        {
            return Activator.CreateInstance<Cat>();
        }
    }

}
