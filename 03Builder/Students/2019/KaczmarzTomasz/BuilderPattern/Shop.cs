using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Shop
    {
        public Computer Construct(ComputerBuilder builder)
        {
            return builder;
        }
    }
}
