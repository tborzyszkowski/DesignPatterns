using System;

using FactoryPattern.AbstractFactory.Abstraction;
using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Models;

namespace FactoryPattern.AbstractFactory
{
    public class HpComputerFactory : IComputerFactory
    {
        private static readonly Lazy<HpComputerFactory> lazyIstance = new Lazy<HpComputerFactory>(() => new HpComputerFactory());

        private HpComputerFactory() { }

        public static HpComputerFactory Instance
        {
            get { return lazyIstance.Value; }
        }

        public IGamingPC CreateGamingPC()
        {
            return new HpGamingPC();
        }

        public IWorkStation CreateWorkStation()
        {
            return new HpWorkStation();
        }
    }
}
