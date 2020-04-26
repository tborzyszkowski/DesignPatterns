using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02DataOperations {

	// The 'RefinedAbstraction' class

	class Customers : CustomersBase {
		public Customers(string group)
		  : base(group) {
		}

		public override void ShowAll() {
			Console.WriteLine();
			Console.WriteLine("------------------------");
			base.ShowAll();
			Console.WriteLine("------------------------");
		}
	}
}
