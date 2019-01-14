using Factory.Manufacturing;
using Factory.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class TeacherFactory : FactoryMethod
    {
        private static readonly Lazy<TeacherFactory> factory = new Lazy<TeacherFactory>(() => new TeacherFactory());

        public static new FactoryMethod GetFactory()
        {
            return factory.Value;
        }

        public override IPerson GetPerson<T>()
        {
            return (ITeacher) typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        public override IPerson GetPersonWithoutReflection(Type type)
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
