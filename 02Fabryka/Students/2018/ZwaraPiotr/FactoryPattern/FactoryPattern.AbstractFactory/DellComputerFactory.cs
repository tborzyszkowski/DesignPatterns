using System;

using FactoryPattern.AbstractFactory.Abstraction;
using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Models;

namespace FactoryPattern.AbstractFactory
{
    public class DellComputerFactory : IComputerFactory
    {
        private static readonly Lazy<DellComputerFactory> lazyIstance = new Lazy<DellComputerFactory>(() => new DellComputerFactory());

        private DellComputerFactory() { }

        public static DellComputerFactory Instance
        {
            get { return lazyIstance.Value; }
        }

        public IGamingPC CreateGamingPC()
        {
            return new DellGamingPC();
        }

        public IWorkStation CreateWorkStation()
        {
            return new DellWorkStation();
        }
    }
}
