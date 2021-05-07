using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
	class ConcreteObserver : Observer {
		private string _name;
		private string _observerState;

		public ConcreteSubject Subject { get; set; }

		public ConcreteObserver(
		  ConcreteSubject subject, string name) {
			this.Subject = subject;
			this._name = name;
		}

		public override void Update() {
			_observerState = Subject.SubjectState;
			Console.WriteLine("Observer {0}'s new state is {1}",
			  _name, _observerState);
		}

	}
}
