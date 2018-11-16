using System;

using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Models;
using FactoryPattern.FactoryMethod.Abstraction;
using FactoryPattern.FactoryMethod.Enumerations;

namespace FactoryPattern.FactoryMethod
{
    public class HpComputerFactory : IComputerFactory
    {
        private static readonly Lazy<HpComputerFactory> lazyIstance = new Lazy<HpComputerFactory>(() => new HpComputerFactory());

        private HpComputerFactory() { }

        public static HpComputerFactory Instance
        {
            get { return lazyIstance.Value; }
        }

        public IComputer CreateComputer(ComputerType type)
        {
            switch (type)
            {
                case ComputerType.GamingPC:
                    return new HpGamingPC();
                case ComputerType.WorkStation:
                    return new HpWorkStation();
                default:
                    return null;
            }
        }
    }
}
