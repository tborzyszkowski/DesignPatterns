using System;

using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Extensions;
using FactoryPattern.Domain.Models;

namespace FactoryPattern.GenericSolution
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IComputer computer;

            computer = ComputerFactory.Instance.CreateComputer<DellGamingPC>();
            Console.WriteLine(computer.GetDescription());

            computer = ComputerFactory.Instance.CreateComputer<DellWorkStation>();
            Console.WriteLine(computer.GetDescription());

            computer = ComputerFactory.Instance.CreateComputer<HpGamingPC>();
            Console.WriteLine(computer.GetDescription());

            computer = ComputerFactory.Instance.CreateComputer<HpWorkStation>();
            Console.WriteLine(computer.GetDescription());

            Console.ReadKey();
        }
    }
}
