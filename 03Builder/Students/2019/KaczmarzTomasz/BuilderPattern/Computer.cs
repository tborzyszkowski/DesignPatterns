using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    enum ComputerType
    {
        GamingPC,
        OfficePC,
        MidRangePC
    }

    enum Part
    {
        CPU,
        GPU,
        Motherboard,
        RAM
    }

    class Computer
    {
        private ComputerType computerType;
        private Dictionary<Part, string> parts = new Dictionary<Part, string>();

        public Computer(ComputerType type)
        {
            computerType = type;
        }

        public string this[Part type]
        {
            get { return parts[type]; }
            set { parts[type] = value; }
        }

        public void Show()
        {
            Console.WriteLine("COMPUTER SPECS:");
            Console.WriteLine("\tType: " + computerType);
            Console.WriteLine("\tCPU: " + parts[Part.CPU]);
            Console.WriteLine("\tGPU: " + parts[Part.GPU]);
            Console.WriteLine("\tMotherboard: " + parts[Part.Motherboard]);
            Console.WriteLine("\tRAM: " + parts[Part.RAM]);
        }
    }
}
