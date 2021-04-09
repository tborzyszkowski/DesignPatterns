using System;

using FactoryPattern.Domain.Abstraction;
using FactoryPattern.Domain.Enumerations;
using FactoryPattern.Domain.Extensions;
using FactoryPattern.FactoryMethod.Enumerations;

namespace FactoryPattern.FactoryMethod
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IComputer computer;
            var store = new ComputerStore();

            computer = store.SellComputer(ComputerProducer.DELL, ComputerType.GamingPC);
            Console.WriteLine(computer.GetDescription());

            computer = store.SellComputer(ComputerProducer.HP, ComputerType.GamingPC);
            Console.WriteLine(computer.GetDescription());

            computer = store.SellComputer(ComputerProducer.DELL, ComputerType.WorkStation);
            Console.WriteLine(computer.GetDescription());

            computer = store.SellComputer(ComputerProducer.HP, ComputerType.WorkStation);
            Console.WriteLine(computer.GetDescription());

            Console.ReadKey();
        }
    }
}
