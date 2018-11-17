using System;
using System.Diagnostics;

using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Models;
using FactoryPattern.FactoryMethod.Enumerations;

namespace FactoryPattern.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IComputer computer = null;
            var stopwatch = new Stopwatch();

            // ====== FactoryMethod ========

            stopwatch.Start();

            for (int i = 0; i < 1_000_000; i++)
            {
                computer = FactoryMethod.DellComputerFactory.Instance.CreateComputer(ComputerType.GamingPC);
                computer = FactoryMethod.DellComputerFactory.Instance.CreateComputer(ComputerType.WorkStation);
                computer = FactoryMethod.HpComputerFactory.Instance.CreateComputer(ComputerType.GamingPC);
                computer = FactoryMethod.HpComputerFactory.Instance.CreateComputer(ComputerType.WorkStation);
            }

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for FactoryMethod: {stopwatch.ElapsedTicks}");

            stopwatch.Reset();

            // ====== AbstractFactory ======

            stopwatch.Start();

            for (int i = 0; i < 1_000_000; i++)
            {
                computer = AbstractFactory.DellComputerFactory.Instance.CreateGamingPC();
                computer = AbstractFactory.DellComputerFactory.Instance.CreateWorkStation();
                computer = AbstractFactory.HpComputerFactory.Instance.CreateGamingPC();
                computer = AbstractFactory.HpComputerFactory.Instance.CreateWorkStation();
            }

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for AbstractFactory: {stopwatch.ElapsedTicks}");

            stopwatch.Reset();

            // ====== Reflection ===========

            ReflectionSolution.ComputerFactory.Instance.RegisterAllComputers();
            stopwatch.Start();

            for (int i = 0; i < 1_000_000; i++)
            {
                computer = ReflectionSolution.ComputerFactory.Instance.CreateComputer(nameof(DellGamingPC));
                computer = ReflectionSolution.ComputerFactory.Instance.CreateComputer(nameof(DellWorkStation));
                computer = ReflectionSolution.ComputerFactory.Instance.CreateComputer(nameof(HpGamingPC));
                computer = ReflectionSolution.ComputerFactory.Instance.CreateComputer(nameof(HpWorkStation));
            }

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for Reflection solution: {stopwatch.ElapsedTicks}");

            stopwatch.Reset();

            // ====== Generic ==============

            stopwatch.Start();

            for (int i = 0; i < 1_000_000; i++)
            {
                computer = GenericSolution.ComputerFactory.Instance.CreateComputer<DellGamingPC>();
                computer = GenericSolution.ComputerFactory.Instance.CreateComputer<DellWorkStation>();
                computer = GenericSolution.ComputerFactory.Instance.CreateComputer<HpGamingPC>();
                computer = GenericSolution.ComputerFactory.Instance.CreateComputer<HpWorkStation>();
            }

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for Generic solution: {stopwatch.ElapsedTicks}");

            Console.ReadKey();
        }
    }
}
