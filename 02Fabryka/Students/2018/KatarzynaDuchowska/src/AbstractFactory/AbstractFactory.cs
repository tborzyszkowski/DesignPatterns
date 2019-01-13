using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract IPerson CreateTeacher();
        public abstract IPerson CreateDoctor();
        public abstract IPerson CreateArtist();

        public abstract IPerson CreatePerson<T>();

        public static AbstractFactory GetFactory() { return null; }
    }
}
