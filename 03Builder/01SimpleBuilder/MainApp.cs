using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimpleBuilder {
	class MainApp {
		static void Main(string[] args) {
			var director = new Director();

			var b1 = new ConcreteBuilder1();
			var b2 = new ConcreteBuilder2();

			director.Construct(b1);
			var p1 = b1.GetResult();
			p1.Show();

			director.Construct(b2);
			var p2 = b2.GetResult();
			p2.Show();
		}
	}
}
