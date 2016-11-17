using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    // Implementing the required standard via Adaptee
    class Adapter : Adaptee, ITarget {
        public string Request(int i) {
            return "Rough estimate is " + (int)Math.Round(SpecificRequest(i, 3));
        }
    }
}
