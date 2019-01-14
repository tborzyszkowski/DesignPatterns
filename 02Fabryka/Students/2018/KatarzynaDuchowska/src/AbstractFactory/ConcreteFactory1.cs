using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Artist;
using Factory.Doctor;
using Factory.Teacher;

namespace Factory.AbstractFactory
{
    public class ConcreteFactory1 : AbstractFactory
    {
        private static readonly Lazy<ConcreteFactory1> factory = new Lazy<ConcreteFactory1>(() => new ConcreteFactory1());

        public new static AbstractFactory GetFactory()
        {
            return factory.Value;
        }

        public override IPerson CreateArtist()
        {
            return new Actor();
        }

        public override IPerson CreateDoctor()
        {
            return new Cardiologist();
        }

        public override IPerson CreatePerson<T>()
        {
            return (IDoctor) typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        public override IPerson CreateTeacher()
        {
            return new EnglishTeacher();
        }
    }
}
