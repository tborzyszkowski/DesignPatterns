using System;

namespace Builder.FactoryBetter.Factory.Computers.Notebook
{
    public abstract class Notebook : IComputer
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int ProdYear { get; set; }
        public int Price { get; set; }

        public double Inches { get; set; }

        public void setUp()
        {
            Console.WriteLine("Setting up Notebook software.");
        }
        public void build()
        {
            Console.WriteLine("Building Notebook construction.");
        }
    }
}
