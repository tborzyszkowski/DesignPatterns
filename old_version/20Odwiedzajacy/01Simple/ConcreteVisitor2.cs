using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteVisitor2 : Visitor {
        public override void Visit(ConcreteElementA concreteElementA) {
            Console.WriteLine($"A: {concreteElementA.GetType().Name} visited by {this.GetType().Name}");
        }

        public override void Visit(ConcreteElementB concreteElementB) {
            Console.WriteLine($"B: {concreteElementB.GetType().Name} visited by {this.GetType().Name}");
        }
    }
}
