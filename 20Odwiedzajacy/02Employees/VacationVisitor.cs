﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Employees {
	class VacationVisitor : IVisitor {
		public void Visit(Element element) {
			Employee employee = element as Employee;

			// Provide 3 extra vacation days
			employee.VacationDays += 3;
			Console.WriteLine($"{employee.GetType().Name} {employee.Name}'s new vacation days: {employee.VacationDays}");
		}
	}
}
