using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.AbstractFactory.ComputerFactory
{
    public class PolandFactory : IFactory
    {
        private static Lazy<PolandFactory> instanceComputer = new Lazy<PolandFactory>(CreateInstance);

        private static PolandFactory CreateInstance()
        {
            return Activator.CreateInstance(typeof(PolandFactory), true) as PolandFactory;
        }
        public static PolandFactory Instance
        {
            get { return instanceComputer.Value; }
        }
        public Computer CreateComputer()
        {
            return new SuperComputer();
        }
    }
}
