using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractProductProcess factory;

            factory = new LaptopProcess();
            factory.CreateNew("Omen");
            Console.WriteLine(factory.GetInfo("Omen"));
            factory = new TelevisorProcess();
            factory.CreateNew("Samsung");
            Console.WriteLine(factory.GetInfo("Samsung"));
            factory = new MobilePhoneProcess();
            factory.CreateNew("Mate");
            Console.WriteLine(factory.GetInfo("Mate"));
            Console.ReadKey();
        }
    }
}
