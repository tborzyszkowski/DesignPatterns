using System;
using System.Collections.Generic;
using System.Linq;

using FactoryPattern.Domain.Abstraction;

namespace FactoryPattern.ReflectionSolution
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

        public void RegisterComputer(string computerId, Type computerType)
        {
            this.registeredComputers.Add(computerId, computerType);
        }

        public void RegisterAllComputers()
        {
            Type interfaceType = typeof(IComputer);
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass);

            foreach (Type type in types)
                Instance.RegisterComputer(type.Name, type);
        }

        public IComputer CreateComputer(string computerId)
        {
            IComputer computer = this.registeredComputers.TryGetValue(computerId, out Type computerType)
                ? (IComputer)Activator.CreateInstance(computerType)
                : null;

            // if (computer != null) some additional logic here ...

            return computer;
        }
    }
}
