using Factory;
using Factory.Doctor;
using Factory.Manufacturing;
using Factory.Teacher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class FactoryMethodTest
    {
        [TestMethod]
        public void DentistCreationTest()
        {
            FactoryMethod factory = DoctorFactory.GetFactory();
            IPerson x = factory.GetPerson<Pneumologist>();

            Assert.AreSame(x.GetType(), typeof(Pneumologist));
        }

        [TestMethod]
        public void DentistCreationWithoutReflectionTest()
        {
            FactoryMethod factory = DoctorFactory.GetFactory();
            IPerson x = factory.GetPersonWithoutReflection(typeof(Pneumologist));

            Assert.AreSame(x.GetType(), typeof(Pneumologist));
        }


        [TestMethod]
        public void GermanTeacherCreationTest()
        {
            FactoryMethod factory = TeacherFactory.GetFactory();
            IPerson x = factory.GetPerson<GermanTeacher>();

            Assert.AreSame(x.GetType(), typeof(GermanTeacher));
        }

        [TestMethod]
        public void GermanTeacherCreationWithoutReflectionTest()
        {
            FactoryMethod factory = TeacherFactory.GetFactory();
            IPerson x = factory.GetPersonWithoutReflection(typeof(GermanTeacher));

            Assert.AreSame(x.GetType(), typeof(GermanTeacher));
        }
    }
}

