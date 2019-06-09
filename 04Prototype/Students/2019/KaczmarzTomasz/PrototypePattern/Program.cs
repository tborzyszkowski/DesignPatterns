using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerManager manager = new ComputerManager();

            manager["gaming"] = new Computer("Intel Core i9", "GeForce RTX 2080Ti", "32GB 3200MHz DDR4");
            manager["mid"] = new Computer("AMD Ryzen 5", "AMD Radeon RX580", "16GB 2400MHz DDR4");

            Computer c1 = manager["gaming"].Clone() as Computer;
            Computer c2 = manager["mid"].Clone() as Computer;

            Console.WriteLine("Cloned: " + c1);
            Console.WriteLine("Cloned: " + c2);

            Console.ReadKey();
        }
    }
}
