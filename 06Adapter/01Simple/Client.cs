using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    // Simplest adapter using interfaces and inheritance
    class Client {
        static void Main() {
            // Showing the Adapteee in standalone mode
            Adaptee first = new Adaptee();
            Console.Write("Before the new standard\nPrecise reading: ");
            Console.WriteLine(first.SpecificRequest(5, 3));

            // What the client really wants
            ITarget second = new Adapter();
            Console.WriteLine("\nMoving to the new standard");
            Console.WriteLine(second.Request(5));
        }
    }
}
