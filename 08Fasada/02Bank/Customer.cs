using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Bank {
    class Customer {
        private string _name;

        // Constructor
        public Customer(string name) {
            this._name = name;
        }

        // Gets the name
        public string Name
        {
            get { return _name; }
        }
    }
}
