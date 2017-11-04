using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class IntelFactory : AbstractFactoryInterface
    {
        public Disc createDisc()
        {
            return new HDD();
        }

        public Processor createProcessor()
        {
            return new IntelProcessor();
        }
    }
}
