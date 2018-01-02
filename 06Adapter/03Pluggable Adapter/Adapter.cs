using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Pluggable_Adapter {
    // Implementing new requests via old
    class Adapter : Adaptee {
        public Func<int, string> Request;

        // Different constructors for the expected targets/adaptees

        // Adapter-Adaptee
        public Adapter(Adaptee adaptee) {
            // Set the delegate to the new standard
            Request = i =>
                $"Estimate based on precision is {(int)Math.Round(Precise(i, 3))}";
        }

        // Adapter-Target
        public Adapter(Target target) {
            // Set the delegate to the existing standard
            Request = target.Estimate;
        }

        public void ChangeRequest(Func<int, string> ff) {
            Request = ff;
        }
    }
}
