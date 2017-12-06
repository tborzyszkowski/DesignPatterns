using System;
using WzorceFactory.Fabryka;

namespace WzorceFactory
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var factory = new ZooFactory();
            var zooFactoryA = new ZooFactoryA(factory);

            var animal = zooFactoryA.CreateAnimal("Dog");
            Console.WriteLine(animal.GetType());

            animal = zooFactoryA.CreateAnimal("Cat");
            Console.WriteLine(animal.GetType());

            animal = zooFactoryA.CreateAnimal("Bear");
            Console.WriteLine(animal.GetType());

            animal = zooFactoryA.CreateAnimal("Hedgehog");
            Console.WriteLine(animal.GetType());
        }
    }
}