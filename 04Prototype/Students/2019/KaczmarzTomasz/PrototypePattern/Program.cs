using System;
using PrototypePattern.Deep;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerManager manager = new ComputerManager();

            manager["gaming"] = new Computer("Intel Core i9", "GeForce RTX 2080Ti", "32GB 3200MHz DDR4", new Casing(new PowerSupply(800, new Fan(180))));
            manager["mid"] = new Computer("AMD Ryzen 5", "AMD Radeon RX580", "16GB 2400MHz DDR4", new Casing(new PowerSupply(550, new Fan(120))));

            Computer c1 = manager["gaming"].Clone() as Computer;
            Computer c2 = manager["mid"].DeepCopy() as Computer;

            Console.WriteLine("\t=== SHALLOW ===");
            Report(manager["gaming"], c1);
            c1.casing.powerSupply.fan.diameter = 150;
            Report(manager["gaming"], c1);

            Console.WriteLine("\t=== DEEP ===");

            Report(manager["mid"], c2);
            c2.casing.powerSupply.fan.diameter = 150;
            Report(manager["mid"], c2);

            Console.ReadKey();
        }

        static void Report(ComputerPrototype a, ComputerPrototype b)
        {
            Console.WriteLine("Prototype: {0}\nClone: {1}", a, b);
        }
    }
}
