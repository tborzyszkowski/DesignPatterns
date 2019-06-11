using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Model.GPU
{
    class RX580 : GPU
    {
        public RX580()
        {
            Make = "AMD";
            Model = "Radeon RX580";
            CoreSpeed = 1340;
            Memory = 8;
        }
    }
}
