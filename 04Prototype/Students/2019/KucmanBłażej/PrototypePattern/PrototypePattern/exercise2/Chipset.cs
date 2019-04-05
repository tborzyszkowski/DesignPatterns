using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.exercise2
{
    [Serializable()]
    public class Chipset
    {
        public Chipset(string namen, Producent producent)
        {
            name = name;
            this.producent = producent;
        }

        public string name { get; set; }
        public Producent producent { get; set; }
    }
}
