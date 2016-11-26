using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteImplementorA : Implementor {
        public override void Operation() {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }

}
