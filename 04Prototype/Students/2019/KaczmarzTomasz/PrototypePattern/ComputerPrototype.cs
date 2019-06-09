using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    abstract class ComputerPrototype
    {
        public abstract ComputerPrototype Clone();
    }

    class Computer : ComputerPrototype
    {
        private string cpu;
        private string gpu;
        private string ram;

        public Computer(string cpu, string gpu, string ram)
        {
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
        }

        public override ComputerPrototype Clone()
        {
            Console.WriteLine("Cloning computer: {0}, {1}, {2}", cpu, gpu, ram);
            return this.MemberwiseClone() as ComputerPrototype;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", cpu, gpu, ram);
        }
    }
}
