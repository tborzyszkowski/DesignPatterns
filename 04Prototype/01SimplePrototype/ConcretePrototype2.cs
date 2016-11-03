using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePrototype {
    class ConcretePrototype2 : Prototype {
        // Constructor
        public ConcretePrototype2(string id)
          : base(id) {
        }

        // Returns a shallow copy
        public override Prototype Clone() {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
