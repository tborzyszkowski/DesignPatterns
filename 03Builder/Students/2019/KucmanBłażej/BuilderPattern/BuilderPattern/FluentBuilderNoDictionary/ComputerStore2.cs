using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.FluentBuilder2
{
    public class ComputerStore2
    {
        public Computer2 Construct(ComputerBuilder2 computerBuilder)
        {
            return computerBuilder;
        }
    }
}
