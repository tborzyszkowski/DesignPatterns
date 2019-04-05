using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.exercise2
{
    [Serializable()]
    public class Motherboard
    {
        public Motherboard(string name, Chipset chipset)
        {
            this.name = name;
            this.chipset = chipset;
        }

        public string name { get; set; }
        public Chipset chipset { get; set; }
    }
}
