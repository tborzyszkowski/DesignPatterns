using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteClassB : AbstractClass {
        public override void PrimitiveOperation1() {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
        }
        public override void PrimitiveOperation2() {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
        }
        public override void OptionalOperation() {
            base.OptionalOperation();
            Console.WriteLine("ConcreteClassB.OptionalOperation()");
        }
    }
}
