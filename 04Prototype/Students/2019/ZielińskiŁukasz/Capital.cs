using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    [Serializable()]
    public class Capital
    {
        public Capital(string name, string population)
        {
            this.Name = name;
            this.Population = population;
        }
        public string Name { get; set; }
        public string Population { get; set; }

    }
}
