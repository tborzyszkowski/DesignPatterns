using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder
{
    public class ComputerStore
    {
        public Computer Construct(ComputerBuilder computerBuilder)
        {
            return computerBuilder;
        }
    }
}
