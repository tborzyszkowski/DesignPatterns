using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteClassA : AbstractClass {
        public override void PrimitiveOperation1() {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }
        public override void PrimitiveOperation2() {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }
}
