using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class HpiFactory : AbstractFactoryInterface
    {
        public Battery inputBattery()
        {
            return new S3();
        }

        public Engine inputEngine()
        {
            return new HpiEngine();
        }
    }
}
