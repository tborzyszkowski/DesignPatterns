using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Deep
{
    [Serializable]
    class Fan
    {
        public int diameter;

        public Fan(int diameter)
        {
            this.diameter = diameter;
        }
    }
}
