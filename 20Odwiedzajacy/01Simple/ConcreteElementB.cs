using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteElementB : Element {
        public override void Accept(Visitor visitor) {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB() {
        }
    }
}
