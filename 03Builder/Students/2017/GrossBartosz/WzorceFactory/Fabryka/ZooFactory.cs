using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WzorceFactory.Animals;

namespace WzorceFactory.Fabryka
{
    public class ZooFactory
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
            if (type.Equals("Andrzej"))
            {
                SomeDnaModyfication();
                return ChangeAndrzejDudanHistory();
            }
            return type.Equals("Dog") ? new Dog() : null;
        }

        private void SomeDnaModyfication()
        {
            Console.WriteLine("Changing Andrzej DNA in progress");

            for (int i=0; i < 1000000; i++ )
            {
                var aa = new ZooFactory();
                //Thread.Sleep(2000);
            }
        }

        private Andrzej ChangeAndrzejDudanHistory()
        {
            var andrzejD = new Andrzej
            {
                AndrzejDudanHistory = new List<string>() {"Country : Lechia Empire", "Profession : Best King ever"}
            };

            return andrzejD;
        }
    }


    public class ZooFactoryA
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
