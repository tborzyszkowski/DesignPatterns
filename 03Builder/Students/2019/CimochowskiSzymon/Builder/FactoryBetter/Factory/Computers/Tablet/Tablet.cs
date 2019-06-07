using System;

namespace Builder.FactoryBetter.Factory.Computers.Tablet
{
    public abstract class Tablet : IComputer
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int ProdYear { get; set; }
        public int Price { get; set; }

        public string OperatingSystem { get; set; }

        public void setUp()
        {
            Console.WriteLine("Setting up Tablet software.");
        }
        public void build()
        {
            Console.WriteLine("Building Tablet construction.");
        }
    }
}
