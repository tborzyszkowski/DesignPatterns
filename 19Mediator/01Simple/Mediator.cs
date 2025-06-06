using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    abstract class Mediator {
        private Colleague _colleague1;
        private Colleague _colleague2;

        public Colleague Colleague1
        {
            get { return _colleague1; }
            set { _colleague1 = value; }
        }

        public Colleague Colleague2
        {
            get { return _colleague2;}
            set { _colleague2 = value; }
        }
        public abstract void Send(string message, Colleague colleague);
    }
}
