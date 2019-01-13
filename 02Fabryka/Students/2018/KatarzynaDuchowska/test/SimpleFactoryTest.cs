using System;
using Factory;
using Factory.Artist;
using Factory.Doctor;
using Factory.Teacher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class SimpleFactoryTest
    {
        [TestMethod]
        public void PneumologistCreationTest()
        {
            SimpleFactory factory = SimpleFactory.GetFactory();
            IPerson x = factory.GetPerson<Pneumologist>();

            Assert.AreSame(x.GetType(), typeof(Pneumologist));
        }

        [TestMethod]
        public void PneumologistCreationWithoutReflectionTest()
        {
            SimpleFactory factory = SimpleFactory.GetFactory();
            IDoctor x = factory.GetDoctor(typeof(Pneumologist));

            Assert.AreSame(x.GetType(), typeof(Pneumologist));
        }

        [TestMethod]
        public void MathTeacherCreationTest()
        {
            SimpleFactory factory = SimpleFactory.GetFactory();
            IPerson x = factory.GetPerson<MathTeacher>();

            Assert.AreSame(x.GetType(), typeof(MathTeacher));
        }

        [TestMethod]
        public void MathTeacherCreationWithoutReflectionTest()
        {
            SimpleFactory factory = SimpleFactory.GetFactory();
            ITeacher x = factory.GetTeacher(typeof(MathTeacher));

            Assert.AreSame(x.GetType(), typeof(MathTeacher));
        }

        [TestMethod]
        public void PainterCreationTest()
        {
            SimpleFactory factory = SimpleFactory.GetFactory();
            IPerson x = factory.GetPerson<Painter>();

            Assert.AreSame(x.GetType(), typeof(Painter));
        }

        [TestMethod]
        public void PainterCreationWithoutReflectionTest()
        {
            SimpleFactory factory = SimpleFactory.GetFactory();
            IArtist x = factory.GetArtist(typeof(Painter));

            Assert.AreSame(x.GetType(), typeof(Painter));
        }
    }
}
