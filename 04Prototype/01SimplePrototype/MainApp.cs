using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePrototype {
    class MainApp {
        static void Main(string[] args) {
            // Create two instances and clone each

            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
            Console.WriteLine($"Cloned: c1: {c1.Id} p1: {p1.Id}");
            p1.Id = "X";
            Console.WriteLine($"Cloned: c1: {c1.Id} p1: {p1.Id}");

            ConcretePrototype2 p2 = new ConcretePrototype2("II");
            ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
            Console.WriteLine($"Cloned: c2: {c2.Id} p2: {p2.Id}");
        }
    }
}
