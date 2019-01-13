using Factory.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Manufacturing
{
    public class DoctorFactory : FactoryMethod
    {
        private static readonly Lazy<DoctorFactory> factory = new Lazy<DoctorFactory>(() => new DoctorFactory());

        public new static FactoryMethod GetFactory()
        {
            return factory.Value;
        }

        public override IPerson GetPerson<T>()
        {
            return (IDoctor)typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
        }

        public override IPerson GetPersonWithoutReflection(Type type)
        {
            if (type == typeof(Cardiologist)) return new Cardiologist();
            if (type == typeof(Dentist)) return new Dentist();
            if (type == typeof(Neurologist)) return new Neurologist();
            if (type == typeof(Pneumologist)) return new Pneumologist();
            if (type == typeof(Psychologist)) return new Psychologist();

            throw new Exception("Doctor does not exist");
        }
    }
}
