using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FluentBuilder {
	// 
	// See more on FluentInterface:
	// http://www.martinfowler.com/bliki/FluentInterface.html
	class MainApp {
		static void Main(string[] args) {
			Shop shop = new Shop();

			//Vehicle scooter = shop.Construct(new ScooterBuilder());
			Vehicle scooter = new ScooterBuilder();
			scooter.Show();

			shop.Construct(new CarBuilder()).Show();
		}
	}
}
