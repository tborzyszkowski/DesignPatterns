using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class ComputerManager
    {
        private Dictionary<string, ComputerPrototype> computers = new Dictionary<string, ComputerPrototype>();

        public ComputerPrototype this[string key]
        {
            get { return computers[key]; }
            set { computers.Add(key, value); }
        }
    }
}
