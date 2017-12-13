using System;
using System.Reflection;
using FactoryReflection.Animals;

namespace FactoryReflection.Fabryka
{
    internal abstract class Zoo
    {
        //Generic
        public static Animal GetAnimal<T>() where T : Animal
        {
            return Activator.CreateInstance<T>();
        }

        //Reflection
        public static Animal GetAnimal(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(name).FullName;
            return (Animal)Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();
        }
    }


    internal class ZooA : Zoo
    {
    }

    internal class ZooB : Zoo
    {
        //public override Animal FactoryMethod()
        //{
        //    return Activator.CreateInstance<Cat>();
        //}
    }

}
