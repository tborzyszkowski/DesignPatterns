using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class ShoesManager
    {
        private Dictionary<string, ShoesPrototype> _shoes =
        new Dictionary<string, ShoesPrototype>();

        public ShoesPrototype this[string key]
        {
            get { return _shoes[key]; }
            set { _shoes.Add(key, value); }
        }
    }
}
