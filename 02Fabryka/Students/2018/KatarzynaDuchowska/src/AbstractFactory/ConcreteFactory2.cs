using Factory.Artist;
using Factory.Doctor;
using Factory.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.AbstractFactory
{
    public class ConcreteFactory2 : AbstractFactory
    {
        private static readonly Lazy<ConcreteFactory2> factory = new Lazy<ConcreteFactory2>(() => new ConcreteFactory2());

        public new static AbstractFactory GetFactory()
        {
            return factory.Value;
        }

        public override IPerson CreateArtist()
        {
            return new Dancer();
        }

        public override IPerson CreateDoctor()
        {
            return new Dentist();
        }

        public override IPerson CreatePerson<T>()
        {
            return (ITeacher)typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        public override IPerson CreateTeacher()
        {
            return new MathTeacher();
        }
    }
}
