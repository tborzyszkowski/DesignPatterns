using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Deep
{
    [Serializable]
    class PowerSupply
    {
        public int power;
        public Fan fan;

        public PowerSupply(int watts, Fan fan)
        {
            power = watts;
            this.fan = fan;
        }
    }
}
