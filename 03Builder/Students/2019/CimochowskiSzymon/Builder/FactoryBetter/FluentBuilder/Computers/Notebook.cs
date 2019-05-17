using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.FactoryBetter.FluentBuilder.Computers
{
    public class Notebook : IComputer
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Country { get; set; }
        public int ProdYear { get; set; }
        public int Price { get; set; }

        public double Inches { get; set; }

        public void setUp()
        {
            Console.WriteLine($"Setting up {Manufacturer} Notebook software.");
        }
        public void build()
        {
            Console.WriteLine($"Building {Manufacturer} Notebook construction.");
        }
    }

}
