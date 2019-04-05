using BuilderPattern.AbstractFactory.ComputerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.AbstractFactory
{
    public class AbstractFactory
    {
        private readonly IFactory factory;

        protected AbstractFactory(IFactory factory)
        {
            this.factory = factory;
        }

        public Computer CreateComputer()
        {
            return factory.CreateComputer();
        }
    }
}
