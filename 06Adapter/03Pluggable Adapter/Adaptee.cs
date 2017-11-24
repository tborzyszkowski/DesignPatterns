using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Pluggable_Adapter {
    // Existing way requests are implemented
    class Adaptee {
        public double Precise(double a, double b) => a / b;
    }
}
