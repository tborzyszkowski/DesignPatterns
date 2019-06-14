using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class OfficeBuilder : ComputerBuilder
    {
        public OfficeBuilder()
        {
            computer = new Computer(ComputerType.OfficePC);
        }

        public override ComputerBuilder BuildCPU()
        {
            computer[Part.CPU] = "Intel Core i3-8100";
            return this;
        }

        public override ComputerBuilder BuildGPU()
        {
            computer[Part.GPU] = "Intel UHD Graphics 630";
            return this;
        }

        public override ComputerBuilder BuildMotherboard()
        {
            computer[Part.Motherboard] = "Gigabyte GA-H110-D3A";
            return this;
        }

        public override ComputerBuilder BuildRAM()
        {
            computer[Part.RAM] = "GOODRAM 8GB 2400MHz";
            return this;
        }
    }
}
