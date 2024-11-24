using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
	class MainApp {
		static void Main(string[] args) {
			ConcreteSubject s = new ConcreteSubject();

			var observerX = new ConcreteObserver(s, "X");
			s.Attach(observerX);
			var observerY = new ConcreteObserver(s, "Y");
			s.Attach(observerY);
			var observerZ = new ConcreteObserver(s, "Z");
			s.Attach(observerZ);

			s.SubjectState = "ABC";
			//s.Notify();
			s.Detach(observerX);
			s.SubjectState = "XYZ";
			s.Detach(observerY);
			s.Detach(observerZ);
			s.SubjectState = "qwerty";
		}
	}
}
