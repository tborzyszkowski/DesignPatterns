using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Inwestors {
	class MainApp {
		static void Main(string[] args) {
			IBM ibm = new IBM("IBM", 120.00);
			var investor = new Investor("Sorros");
			ibm.Attach(investor);
			var kowalski = new Investor("Kowalski");
			ibm.Attach(kowalski);

			// Fluctuating prices will notify investors
			ibm.Price = 120.10;
			ibm.Price = 121.00;
			ibm.Detach(kowalski);
			ibm.Price = 120.50;
			ibm.Price = 120.75;
			ibm.Detach(investor);
			ibm.Price = 130.50;
			ibm.Price = 130.75;
		}
	}
}
