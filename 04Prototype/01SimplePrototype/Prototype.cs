using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePrototype {
    abstract class Prototype {
        private string _id;

        // Constructor
        public Prototype(string id) {
            this._id = id;
        }

        // Gets id
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public abstract Prototype Clone();
    }
}
