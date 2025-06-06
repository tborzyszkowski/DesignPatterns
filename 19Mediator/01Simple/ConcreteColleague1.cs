using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteColleague1 : Colleague {
        // Constructor
        public ConcreteColleague1(Mediator mediator)
          : base(mediator) {
        }

        public override void Send(string message) {
            mediator.Send(message, this);
        }

        public override void Notify(string message) {
            Console.WriteLine("Colleague1 gets message: "
              + message + " | " + this.GetHashCode());
        }
    }
}
