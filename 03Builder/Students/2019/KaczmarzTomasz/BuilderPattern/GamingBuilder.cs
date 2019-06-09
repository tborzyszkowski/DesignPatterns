using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class GamingBuilder : ComputerBuilder
    {
        public GamingBuilder()
        {
            computer = new Computer(ComputerType.GamingPC);
        }

        public override ComputerBuilder BuildCPU()
        {
            computer[Part.CPU] = "Intel Core i9-9900K";
            return this;
        }

        public override ComputerBuilder BuildGPU()
        {
            computer[Part.GPU] = "Nvidia GeForce RTX 2080Ti";
            return this;
        }

        public override ComputerBuilder BuildMotherboard()
        {
            computer[Part.Motherboard] = "Gigabyte Z390 AORUS XTREME";
            return this;
        }

        public override ComputerBuilder BuildRAM()
        {
            computer[Part.RAM] = "G.SKILL Trident Z 64GB 3200MHz";
            return this;
        }
    }
}
