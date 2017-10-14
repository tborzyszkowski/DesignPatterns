using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteDecoratorB : Decorator {
        public override void Operation() {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }
        void AddedBehavior() {
            Console.WriteLine("ConcreteDecoratorB.AddedBehavior()");
        }
    }
}
