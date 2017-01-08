using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    abstract class Command {
        protected Receiver receiver;

        // Constructor
        public Command(Receiver receiver) {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }
}
