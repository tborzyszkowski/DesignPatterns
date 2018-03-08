using System;
using System.Collections.Generic;
using System.Text;

namespace _04EmployeeFluentBuilder
{
    public class EmployeeBuilder
    {
        private int id = 1;
        private string firstname = "first";
        private string lastname = "last";
        private DateTime birthdate = DateTime.Today;
        private string street = "street";

        public Employee Build()
        {
            return new Employee(id, firstname, lastname, birthdate, street);
        }

        public EmployeeBuilder WithFirstName(string firstname)
        {
            this.firstname = firstname;
            return this;
        }

        public EmployeeBuilder WithLastName(string lastname)
        {
            this.lastname = lastname;
            return this;
        }

        public EmployeeBuilder WithBirthDate(DateTime birthdate)
        {
            this.birthdate = birthdate;
            return this;
        }

        public EmployeeBuilder WithStreet(string street)
        {
            this.street = street;
            return this;
        }

        public static implicit operator Employee(EmployeeBuilder instance)
        {
            return instance.Build();
        }
    }
}
