using FactoryExamples.Models;
using System;
using System.Reflection;

namespace FactoryExamples.Examples._4._ReflectionFactory
{
    public class ReflectionFactory
    {
        public static Furniture GetFurniture<T>() where T : Furniture
        {
            return Activator.CreateInstance<T>();
        }

        public static Furniture GetFurniture(string typeName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(typeName).FullName;

            return Activator.CreateInstanceFrom(assembly.Location, type).Unwrap() as Furniture;
        }
    }
}
