using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03DeepPrototype {
    class PrototypeClient : IPrototype<Prototype> {

        internal static void Report(string s, Prototype a, Prototype b) {
            Console.WriteLine("\n" + s);
            Console.WriteLine("Prototype " + a + "\nClone      " + b);
        }
    }
}
