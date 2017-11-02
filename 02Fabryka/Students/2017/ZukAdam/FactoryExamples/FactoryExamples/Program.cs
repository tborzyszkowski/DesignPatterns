using FactoryExamples.Examples._1._SimpleFactory;
using FactoryExamples.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleFurnitureFactoryTest();

            Console.ReadKey();
        }

        private static void SimpleFurnitureFactoryTest()
        {
            Logger.AddTestStep("Testing SimpleFurnitureFactory");
            var factory = new SimpleFurnitureFactory();

            FurnitureMaker.Factory = factory;
            var furniture = FurnitureMaker.Make("CoffeeTable");

            Console.WriteLine(string.Format("We ordered coffe table and we've got: {0}", furniture.Name));
        }
    }
}
