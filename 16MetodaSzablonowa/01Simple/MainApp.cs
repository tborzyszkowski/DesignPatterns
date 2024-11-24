using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
	class MainApp {
		static void Main(string[] args) {
			AbstractClass aA = new ConcreteClassA();
			aA.TemplateMethod();

			aA = new ConcreteClassB();
			aA.TemplateMethod();
		}
	}
}
