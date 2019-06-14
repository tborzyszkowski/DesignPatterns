using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    abstract class ComputerBuilder
    {
        protected Computer computer;

        Computer Computer { get { return computer; } }

        public abstract ComputerBuilder BuildCPU();
        public abstract ComputerBuilder BuildGPU();
        public abstract ComputerBuilder BuildMotherboard();
        public abstract ComputerBuilder BuildRAM();

        public static implicit operator Computer(ComputerBuilder builder)
        {
            return builder.BuildCPU().BuildGPU().BuildMotherboard().BuildRAM().Computer;
        }
    }
}
