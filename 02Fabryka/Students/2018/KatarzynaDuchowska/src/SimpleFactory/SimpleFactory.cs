using Factory.Artist;
using Factory.Doctor;
using Factory.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class SimpleFactory
    {
        private static readonly Lazy<SimpleFactory> _factory = new Lazy<SimpleFactory>(() => new SimpleFactory());

        private SimpleFactory() { }

        public static SimpleFactory GetFactory()
        {
            return _factory.Value;
        }

        public IPerson GetPerson<T>()
        {
            return (IPerson) typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        public IPerson GetPerson(Type group, Type person)
        {
            if (group == typeof(IArtist)) return GetArtist(person);
            if (group == typeof(ITeacher)) return GetTeacher(person);
            if (group == typeof(IDoctor)) return GetDoctor(person);

            throw new Exception("Group does not exist");
        }

        public IArtist GetArtist(Type type)
        {
            if (type == typeof(Actor)) return new Actor();
            if (type == typeof(Dancer)) return new Dancer();
            if (type == typeof(Painter)) return new Painter();
            if (type == typeof(Photographer)) return new Photographer();
            if (type == typeof(Singer)) return new Singer();

            throw new Exception("Artist does not exist");
        }

        public IDoctor GetDoctor(Type type)
        {
            if (type == typeof(Cardiologist)) return new Cardiologist();
            if (type == typeof(Dentist)) return new Dentist();
            if (type == typeof(Neurologist)) return new Neurologist();
            if (type == typeof(Pneumologist)) return new Pneumologist();
            if (type == typeof(Psychologist)) return new Psychologist();

            throw new Exception("Doctor does not exist");
        }

        public ITeacher GetTeacher(Type type)
        {
            if (type == typeof(EnglishTeacher)) return new EnglishTeacher();
            if (type == typeof(GermanTeacher)) return new GermanTeacher();
            if (type == typeof(MathTeacher)) return new MathTeacher();
            if (type == typeof(PolishTeacher)) return new PolishTeacher();
            if (type == typeof(ScienceTeacher)) return new ScienceTeacher();

            throw new Exception("Teacher does not exist");
        }
    }
}
