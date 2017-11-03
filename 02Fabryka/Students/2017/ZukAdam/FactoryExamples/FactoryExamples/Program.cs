using FactoryExamples.Examples._1._SimpleFactory;
using FactoryExamples.Examples._2._FactoryMethod;
using FactoryExamples.Examples._3._AbstractFactory;
using FactoryExamples.Examples._4._ReflectionFactory;
using FactoryExamples.Models;
using FactoryExamples.Models.Furnitures;
using FactoryExamples.Utilities;
using System;
using System.Reflection;
using System.Linq;

namespace FactoryExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleFurnitureFactoryTest();
            FactoryMethodTest();
            AbstractFactoryTest();
            ReflectionFactoryTest();

            Console.ReadKey();
        }

        private static void SimpleFurnitureFactoryTest()
        {
            Logger.AddTestStep("Testing SimpleFurnitureFactory");
            var factory = new SimpleFurnitureFactory();

            FurnitureMaker.Factory = factory;
            var furniture = FurnitureMaker.Make("CoffeeTable");

            Console.WriteLine(string.Format("We ordered coffee table and we've got: {0}", furniture.Name));
        }

        private static void FactoryMethodTest()
        {
            Logger.AddTestStep("Testing FactoryMethod");

            Factory factory = null;
            Furniture furniture = null;

            Console.WriteLine("Creating default large desk from LargeDeskFactory");
            factory = new LargeDeskFactory();
            furniture = factory.MakeDefault();
            Console.WriteLine(string.Format("We ordered large desk and we've got: {0}", furniture.Name));

            furniture = factory.CreateWider();
            Console.WriteLine(string.Format("We ordered wider large desk and we've got large desk with width set to: {0}", furniture.Width));
        }

        private static void AbstractFactoryTest()
        {
            Logger.AddTestStep("Testing AbstractFactory");

            AbstractFactory factory = null;
            Furniture furniture = null;

            factory = new EuropeFactory();
            furniture = factory.MakeWideWardrobe();

            Console.WriteLine("We've ordered european version of Wide Wardrobe, becouse it is {0} m width.", furniture.Width);

            factory = new AsiaFactory();
            furniture = factory.MakeWideWardrobe();

            Console.WriteLine("We've ordered asian version of Wide Wardrobe, becouse it is {0} m width.", furniture.Width);
        }

        private static void ReflectionFactoryTest()
        {
            Logger.AddTestStep("Testing ReflectionFactory");

            Furniture furniture = null;

            furniture = ReflectionFactory.GetFurniture<CoffeeTable>();
            Console.WriteLine(string.Format("We ordered coffee table and we've got: {0}", furniture.Name));

            var assembly = Assembly.LoadFile(Environment.CurrentDirectory + @"\Library.dll");

            furniture = ReflectionFactory.GetFurniture(assembly.ExportedTypes.First().FullName);
            Console.WriteLine(string.Format("We ordered large desk and we've got: {0}", furniture.Name));
        }
    }
}
