using System;
using System.Collections.Generic;
using System.Text;

namespace _04EmployeeFluentBuilder {
	public class EmployeeBuilder {
		private int _id = 1;
		private string _firstName = "first";
		private string _lastName = "last";
		private DateTime _birthDate = DateTime.Today;
		private string _street = "street";

		public Employee Build() => new Employee(_id, _firstName, _lastName, _birthDate, _street);

		public EmployeeBuilder WithFirstName(string firstName) {
			this._firstName = firstName;
			return this;
		}
		public EmployeeBuilder WithLastName(string lastName) {
			this._lastName = lastName;
			return this;
		}
		public EmployeeBuilder WithBirthDate(DateTime birthDate) {
			this._birthDate = birthDate;
			return this;
		}
		public EmployeeBuilder WithStreet(string street) {
			this._street = street;
			return this;
		}
		public static implicit operator Employee(EmployeeBuilder instance) => instance.Build();
	}
}
