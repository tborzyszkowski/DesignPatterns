using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class TraxasFactory : AbstractFactoryInterface
    {
        public Battery inputBattery()
        {
            return new S2();
        }

        public Engine inputEngine()
        {
            return new TraxasEngine();
        }
    }
}
