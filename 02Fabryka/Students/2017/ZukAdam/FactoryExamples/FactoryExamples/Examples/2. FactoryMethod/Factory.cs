using FactoryExamples.Models;

namespace FactoryExamples.Examples._2._FactoryMethod
{
    public abstract class Factory
    {
        public abstract Furniture MakeDefault();

        public abstract Furniture CreateWider();
    }
}
