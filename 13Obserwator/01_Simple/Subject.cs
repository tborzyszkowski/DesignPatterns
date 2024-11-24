using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
	abstract class Subject {
		private List<Observer> _observers = new List<Observer>();

		public void Attach(Observer observer) {
			_observers.Add(observer);
		}

		public void Detach(Observer observer) {
			_observers.Remove(observer);
		}

		public void Notify() {
			foreach (var o in _observers)
			{
				o.Update();
			}
		}
	}
}
