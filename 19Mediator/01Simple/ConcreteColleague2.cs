using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteColleague2 : Colleague {
        // Constructor
        public ConcreteColleague2(Mediator mediator)
          : base(mediator) {
        }

        public void Send(string message) {
            mediator.Send(message, this);
        }

        public void Notify(string message) {
            Console.WriteLine("Colleague2 gets message: "
              + message);
        }
    }
}
