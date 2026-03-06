using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteMediator : Mediator {
        
        public override void Send(string message,
          Colleague colleague) {
            Console.WriteLine("Send: " + message + " | " + this.GetHashCode());
            if (colleague == Colleague1) {
                Colleague2.Notify(message);
            }
            else {
                Colleague1.Notify(message);
            }
        }
    }
}
