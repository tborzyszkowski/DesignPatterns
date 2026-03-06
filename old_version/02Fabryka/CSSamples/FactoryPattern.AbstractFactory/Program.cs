using System;

using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Extensions;

namespace FactoryPattern.AbstractFactory
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IGamingPC gamingComputer;
            IWorkStation workStation;

            gamingComputer = DellComputerFactory.Instance.CreateGamingPC();
            Console.WriteLine(gamingComputer.GetDescription());

            workStation = DellComputerFactory.Instance.CreateWorkStation();
            Console.WriteLine(workStation.GetDescription());

            gamingComputer = HpComputerFactory.Instance.CreateGamingPC();
            Console.WriteLine(gamingComputer.GetDescription());

            workStation = HpComputerFactory.Instance.CreateWorkStation();
            Console.WriteLine(workStation.GetDescription());

            Console.ReadKey();
        }
    }
}
