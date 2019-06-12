using ComputerShop.Model.CPU;
using ComputerShop.Model.GPU;
using ComputerShop.Model.Monitors;
using System;
using System.Diagnostics;

namespace ComputerShop
{
    public class Computer
    {
        public CPU Processor { get; private set; }
        public GPU GraphicsCard { get; private set; }
        public Monitor Monitor { get; private set; }

        public Computer(CPU cpu, GPU gpu, Monitor monitor)
        {
            Processor = cpu;
            GraphicsCard = gpu;
            Monitor = monitor;
        }

        public string ShowSpecs()
        {
            string specs = string.Format("Stworzony komputer:\n{0}\n{1}\n{2}\n", 
                Processor.GetSpecs(), GraphicsCard.GetSpecs(), Monitor.GetSpecs());
            return specs;
        }
    }
}
