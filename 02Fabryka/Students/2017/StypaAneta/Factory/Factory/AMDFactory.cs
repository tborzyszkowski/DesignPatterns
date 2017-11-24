using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class AMDFactory : AbstractFactoryInterface
    {
        public Disc createDisc()
        {
            return new SSD();
        }

        public Processor createProcessor()
        {
            return new AMDProcessor();
        }
    }
}
