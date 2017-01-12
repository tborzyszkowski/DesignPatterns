using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SkipIterator {
    class Item {
        private string _name;

        // Constructor
        public Item(string name) {
            this._name = name;
        }

        // Gets name
        public string Name
        {
            get { return _name; }
        }
    }
}
