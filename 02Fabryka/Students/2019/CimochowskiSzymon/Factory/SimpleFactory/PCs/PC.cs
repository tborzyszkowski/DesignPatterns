using System;

namespace Factory.SimpleFactory.PCs
{
    public abstract class PC : IComputer
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int ProdYear { get; set; }
        public int Price { get; set; }

        public string CaseType { get; set; }

        public void setUp()
        {
            Console.WriteLine("Setting up PC software.");
        }
        public void build()
        {
            Console.WriteLine("Building PC construction.");
        }
    }
}
