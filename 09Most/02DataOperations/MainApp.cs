using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02DataOperations {
	class MainApp {
		static void Main(string[] args) {
			Customers customers = new Customers("Chicago");

			customers.Data = new CustomersData();

			customers.Show();
			customers.Next();
			customers.Show();
			customers.Next();
			customers.Show();
			customers.Add("Henry Velasquez");

			customers.ShowAll();
		}
	}
}
