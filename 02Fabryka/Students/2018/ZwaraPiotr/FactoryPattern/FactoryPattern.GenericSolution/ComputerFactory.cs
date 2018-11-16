using System;
using System.Collections.Generic;

using FactoryPattern.Domain.Abstraction;

namespace FactoryPattern.GenericSolution
{
    public class ComputerFactory
    {
        private readonly Dictionary<string, Type> registeredComputers = new Dictionary<string, Type>();
        private static readonly Lazy<ComputerFactory> lazyIstance = new Lazy<ComputerFactory>(() => new ComputerFactory());

        private ComputerFactory() { }

        public static ComputerFactory Instance
        {
            get { return lazyIstance.Value; }
        }

        public T CreateComputer<T>()
            where T : IComputer, new()
        {
            var computer = new T();

            // some additional logic here ...

            return computer;
        }
    }
}
