using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
    class ConcreteObserver : Observer {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        // Constructor
        public ConcreteObserver(
          ConcreteSubject subject, string name) {
            this._subject = subject;
            this._name = name;
        }

        public override void Update() {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}",
              _name, _observerState);
        }

        // Gets or sets subject
        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }
}
