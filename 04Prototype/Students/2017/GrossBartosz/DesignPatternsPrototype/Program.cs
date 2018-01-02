using DesignPatternsPrototype.BaseShallowAndDeep.Client;
using DesignPatternsPrototype.BaseShallowAndDeep.ConcretePrototype;

namespace DesignPatternsPrototype
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ZooManager zooManager = new ZooManager();
            zooManager.ShallowCat();
            zooManager.DeepDogSerializable();
            zooManager.DeepDogWithReflection();
        }
    }
}