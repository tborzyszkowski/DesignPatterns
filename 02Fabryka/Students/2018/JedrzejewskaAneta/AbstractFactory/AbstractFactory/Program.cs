using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            SamsungPackageFactory factory =  new SamsungPackageFactory();
            Package package = new Package(factory);

            Console.ReadKey();
        }
    }
}
