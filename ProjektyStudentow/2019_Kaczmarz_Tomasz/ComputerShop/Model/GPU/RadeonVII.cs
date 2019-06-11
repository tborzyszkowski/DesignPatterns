using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Model.GPU
{
    class RadeonVII : GPU
    {
        public RadeonVII()
        {
            Make = "AMD";
            Model = "Radeon VII";
            CoreSpeed = 1750;
            Memory = 16;
        }
    }
}
