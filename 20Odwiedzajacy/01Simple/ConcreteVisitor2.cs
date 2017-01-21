using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteVisitor2 : Visitor {
        public override void VisitConcreteElementA(
          ConcreteElementA concreteElementA) {
            Console.WriteLine("{0} visited by {1}",
              concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(
          ConcreteElementB concreteElementB) {
            Console.WriteLine("{0} visited by {1}",
              concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
}
