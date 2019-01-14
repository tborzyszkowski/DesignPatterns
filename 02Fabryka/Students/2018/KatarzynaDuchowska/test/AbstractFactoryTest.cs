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
using Factory.AbstractFactory;
using Factory.Artist;

namespace Test
{

    [TestClass]
    public class AbstractFactoryTest
    {
        [TestMethod]
        public void DoctorCreationTestWithReflectionConcreteFactory1()
        {
            AbstractFactory factory = ConcreteFactory1.GetFactory();
            IPerson x = factory.CreatePerson<Cardiologist>();

            Assert.AreSame(x.GetType(), typeof(Cardiologist));
        }

        [TestMethod]
        public void TeacherCreationTestWithReflectionConcreteFactory2()
        {
            AbstractFactory factory = ConcreteFactory2.GetFactory();
            IPerson x = factory.CreatePerson<MathTeacher>();

            Assert.AreSame(x.GetType(), typeof(MathTeacher));
        }


        [TestMethod]
        public void DoctorCreationWithConcreteFactory1()
        {
            AbstractFactory factory = ConcreteFactory1.GetFactory();
            IPerson x = factory.CreateDoctor();

            Assert.AreSame(x.GetType(), typeof(Cardiologist));
        }

        [TestMethod]
        public void DoctorCreationWithConcreteFactory2()
        {
            AbstractFactory factory = ConcreteFactory2.GetFactory();
            IPerson x = factory.CreateDoctor();

            Assert.AreSame(x.GetType(), typeof(Dentist));
        }

        [TestMethod]
        public void TeacherCreationWithConcreteFactory1()
        {
            AbstractFactory factory = ConcreteFactory1.GetFactory();
            IPerson x = factory.CreateTeacher();

            Assert.AreSame(x.GetType(), typeof(EnglishTeacher));
        }

        [TestMethod]
        public void TeacherCreationWithConcreteFactory2()
        {
            AbstractFactory factory = ConcreteFactory2.GetFactory();
            IPerson x = factory.CreateTeacher();

            Assert.AreSame(x.GetType(), typeof(MathTeacher));
        }

        [TestMethod]
        public void ArtistCreationWithConcreteFactory1()
        {
            AbstractFactory factory = ConcreteFactory1.GetFactory();
            IPerson x = factory.CreateArtist();

            Assert.AreSame(x.GetType(), typeof(Actor));
        }

        [TestMethod]
        public void ArtistCreationWithConcreteFactory2()
        {
            AbstractFactory factory = ConcreteFactory2.GetFactory();
            IPerson x = factory.CreateArtist();

            Assert.AreSame(x.GetType(), typeof(Dancer));
        }
    }

}
