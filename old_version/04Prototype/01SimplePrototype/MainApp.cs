using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePrototype {
	class MainApp {
		static void Main(string[] args) {
			var p1 = new ConcretePrototype1("I");
			var c1 = p1.Clone() as ConcretePrototype1;

			Console.WriteLine($"Cloned: c1: {c1.Id} p1: {p1.Id}");
			p1.Id = "X";
			Console.WriteLine($"Cloned: c1: {c1.Id} p1: {p1.Id}");

			var p2 = new ConcretePrototype2("II");
			var c2 = p2.Clone() as ConcretePrototype2;
			
			Console.WriteLine($"Cloned: c2: {c2.Id} p2: {p2.Id}");
		}
	}
}
