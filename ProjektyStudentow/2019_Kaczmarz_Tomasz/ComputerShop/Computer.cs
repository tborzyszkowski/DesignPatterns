using FactoryPattern.Factories;
using FactoryPattern.Model.CPU;
using FactoryPattern.Model.GPU;
using FactoryPattern.Model.Monitors;
using System;
using System.Diagnostics;

namespace FactoryPattern
{
    class Computer
    {
        public CPU Processor { get; private set; }
        public GPU GraphicsCard { get; private set; }
        public Monitor Monitor { get; private set; }

        public Computer(IAbstractFactory factory)
        {
            Stopwatch watch = Stopwatch.StartNew();
            Processor = factory.CreateCPU();
            GraphicsCard = factory.CreateGPU();
            Monitor = factory.CreateMonitor();
            watch.Stop();
            Console.WriteLine($"ELAPSED {watch.ElapsedMilliseconds}ms ({watch.ElapsedTicks} ticks)");
            ShowSpecs();
        }

        public string ShowSpecs()
        {
            string specs = string.Format("Stworzony komputer:\n{0}\n{1}\n{2}\n", 
                Processor.GetSpecs(), GraphicsCard.GetSpecs(), Monitor.GetSpecs());
            return specs;
        }
    }
}
