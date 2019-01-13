using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Manufacturing
{
    public abstract class FactoryMethod
    {
        public abstract IPerson GetPersonWithoutReflection(Type type);
        public abstract IPerson GetPerson<T>();
        public static FactoryMethod GetFactory() { return null; }
    }
}
