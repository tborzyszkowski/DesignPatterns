using System;

using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Extensions;
using FactoryPattern.Domain.Models;

namespace FactoryPattern.ReflectionSolution
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ComputerFactory.Instance.RegisterAllComputers();

            IComputer computer;

            computer = ComputerFactory.Instance.CreateComputer(nameof(DellGamingPC));
            Console.WriteLine(computer.GetDescription());

            computer = ComputerFactory.Instance.CreateComputer(nameof(DellWorkStation));
            Console.WriteLine(computer.GetDescription());

            computer = ComputerFactory.Instance.CreateComputer(nameof(HpGamingPC));
            Console.WriteLine(computer.GetDescription());

            computer = ComputerFactory.Instance.CreateComputer(nameof(HpWorkStation));
            Console.WriteLine(computer.GetDescription());

            Console.ReadKey();
        }
    }
}
