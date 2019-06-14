using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class MidRangeBuilder : ComputerBuilder
    {
        public MidRangeBuilder()
        {
            computer = new Computer(ComputerType.MidRangePC);
        }

        public override ComputerBuilder BuildCPU()
        {
            computer[Part.CPU] = "AMD Ryzen 5 2600";
            return this;
        }

        public override ComputerBuilder BuildGPU()
        {
            computer[Part.GPU] = "AMD Radeon RX580";
            return this;
        }

        public override ComputerBuilder BuildMotherboard()
        {
            computer[Part.Motherboard] = "MSI B450 TOMAHAWK";
            return this;
        }

        public override ComputerBuilder BuildRAM()
        {
            computer[Part.RAM] = "Corsair Vengeance 16GB 3000MHz";
            return this;
        }
    }
}
