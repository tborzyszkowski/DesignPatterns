using BuilderPattern.AbstractFactory.ComputerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.AbstractFactory
{
    public interface IFactory
    {
        Computer CreateComputer();
    }
}
