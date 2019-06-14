using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Deep
{
    [Serializable]
    class Casing
    {
        public PowerSupply powerSupply;

        public Casing(PowerSupply supply)
        {
            powerSupply = supply;
        }
    }
}
