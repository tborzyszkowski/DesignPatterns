using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    abstract class Visitor {
        public abstract void Visit(ConcreteElementA concreteElementA);
        public abstract void Visit(ConcreteElementB concreteElementB);
    }
}
