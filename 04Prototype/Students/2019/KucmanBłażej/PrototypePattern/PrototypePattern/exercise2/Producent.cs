using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.exercise2
{
    [Serializable()]
    public class Producent
    {
        public Producent(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
    }
}
