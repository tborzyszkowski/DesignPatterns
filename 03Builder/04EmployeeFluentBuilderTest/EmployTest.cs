using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04EmployeeFluentBuilder;

namespace _04EmployeeFluentBuilderTest
{
    [TestClass]
    public class EmployTest
    {
        [TestMethod]
        public void GetFullNameReturnsCombination()
        {
            // Arrange
            Employee emp = new Employee(1, "Kenneth", "Truyers", new DateTime(1970, 1, 1), "My Street");
            // Bad is:
            // - to construct the employee, apart from the relevant data (firstname and lastname) 
            //   we also need to pass in an ID, a birth date and a street
            //   this data is completely irrelevant for this test
            
            // Act
            string fullname = emp.getFullName();

            // Assert
            Assert.AreEqual(fullname, "Kenneth Truyers");
        }

        [TestMethod]
        public void GetAgeReturnsCorrectValueFulentBuilder()
        {
            // Arrange
            Employee emp = new EmployeeBuilder().WithBirthDate(new DateTime(1983, 1, 1));

            // Act
            int age = emp.getAge();

            // Assert
            Assert.AreEqual(age, DateTime.Today.Year - 1983);
        }
    }
}
