using System;
using FactoryReflection.Animals;
using FactoryReflection.Fabryka;

namespace FactoryReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var animal = Zoo.GetAnimal<Bear>();
            var animalReflection = Zoo.GetAnimal("FactoryReflection.Animals.Cat");
            Console.WriteLine(animal.ToString());
            Console.WriteLine(animalReflection.ToString());
        }
    }
}
