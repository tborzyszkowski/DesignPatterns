using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
	class Client {
		static void Main() {
			Adaptee first = new Adaptee();
			Console.Write("Before the new standard\nPrecise reading: ");
			Console.WriteLine(first.SpecificRequest(5, 3));

			ITarget second = new Adapter();
			Console.WriteLine("\nMoving to the new standard");
			Console.WriteLine(second.Request(5));
		}
	}
}
