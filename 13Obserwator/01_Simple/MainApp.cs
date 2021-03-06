using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
	class MainApp {
		static void Main(string[] args) {
			ConcreteSubject s = new ConcreteSubject();

			s.Attach(new ConcreteObserver(s, "X"));
			s.Attach(new ConcreteObserver(s, "Y"));
			s.Attach(new ConcreteObserver(s, "Z"));

			s.SubjectState = "ABC";
			//s.Notify();
			s.SubjectState = "XYZ";
		}
	}
}
