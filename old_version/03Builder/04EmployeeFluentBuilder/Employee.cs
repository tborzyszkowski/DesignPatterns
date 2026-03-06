using System;

namespace _04EmployeeFluentBuilder {
	public class Employee {
		public Employee(int id, string firstname, string lastname, DateTime birthdate, string street) {
			this.ID = id;
			this.FirstName = firstname;
			this.LastName = lastname;
			this.BirthDate = birthdate;
			this.Street = street;
		}

		public int ID { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public DateTime BirthDate { get; private set; }

		public string Street { get; private set; }

		public string GetFullName() => this.FirstName + " " + this.LastName;

		public int GetAge() {
			var today = DateTime.Today;
			var age = today.Year - BirthDate.Year;
			if (BirthDate > today.AddYears(-age)) age--;
			return age;
		}
	}
}
