using System;

using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Models;
using FactoryPattern.FactoryMethod.Abstraction;
using FactoryPattern.FactoryMethod.Enumerations;

namespace FactoryPattern.FactoryMethod
{
    public class DellComputerFactory : IComputerFactory
    {
        private static readonly Lazy<DellComputerFactory> lazyIstance = new Lazy<DellComputerFactory>(() => new DellComputerFactory());

        private DellComputerFactory() { }

        public static DellComputerFactory Instance
        {
            get { return lazyIstance.Value; }
        }

        public IComputer CreateComputer(ComputerType type)
        {
            switch (type)
            {
                case ComputerType.GamingPC:
                    return new DellGamingPC();
                case ComputerType.WorkStation:
                    return new DellWorkStation();
                default:
                    return null;
            }
        }
    }
}
