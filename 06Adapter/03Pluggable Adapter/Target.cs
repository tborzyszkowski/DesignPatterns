using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Pluggable_Adapter {
    // New standard for requests
    class Target {
        public string Estimate(int i) =>
            $"Estimate is {(int)Math.Round(i / 3.0)}";
    }
}
