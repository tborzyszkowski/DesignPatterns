using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteImplementorB : Implementor {
        public override void Operation() {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }
}
