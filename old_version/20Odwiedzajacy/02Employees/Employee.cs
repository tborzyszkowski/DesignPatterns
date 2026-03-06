using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Employees {
	class Employee : Element {
		public string Name { get; set; }
		public double Income { get; set; }
		public int VacationDays { get; set; }

		public Employee(string name, double income,
		  int vacationDays) {
			this.Name = name;
			this.Income = income;
			this.VacationDays = vacationDays;
		}

		public override void Accept(IVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
