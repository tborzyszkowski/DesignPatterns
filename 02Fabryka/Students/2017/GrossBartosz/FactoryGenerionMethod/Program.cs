using System;
using FactoryGenerionMethod.Fabryka;

namespace FactoryGenerionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ZooFactory headadadaDog = new ZooFactoryA();
            ZooFactory catBear = new ZooFactoryB();

            Animal car = headadadaDog.CreateAnimal("Hedgehog");
            Console.WriteLine($"Janusz ordered: {car.GetType()}");

            car = headadadaDog.CreateAnimal("Dog");
            Console.WriteLine($"John ordered: {car.GetType()}");

            car = catBear.CreateAnimal("Cat");
            Console.WriteLine($"Pope ordered: {car.GetType()}");

            car = catBear.CreateAnimal("Bear");
            Console.WriteLine($"Grazynka ordered: {car.GetType()}");
        }
    }
}
