using WzorceFactory.Animals;

namespace WzorceFactory.Fabryka
{
    internal class ZooFactory
    {
        public Animal CreateAnimal(string type)
        {
            if (type.Equals("Hedgehog"))
            {
                return new Hedgehog();
            }
            if (type.Equals("Cat"))
            {
                return new Cat();
            }
            if (type.Equals("Bear"))
            {
                return new Bear();
            }
            return type.Equals("Dog") ? new Dog() : null;
        }
    }


    internal class ZooFactoryA
    {
        public ZooFactory ZooFactory;
        public ZooFactoryA(ZooFactory zooFactory)
        {
            this.ZooFactory = zooFactory;
        }
        public Animal CreateAnimal(string type)
        {
            Animal animal = ZooFactory.CreateAnimal(type);
            return animal;
        }
    }
}
