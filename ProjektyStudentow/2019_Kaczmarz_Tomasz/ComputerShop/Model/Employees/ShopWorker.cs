using FactoryPattern;
using FactoryPattern.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Model.Employees
{
    class ShopWorker : Employee
    {
        public override string ProcessOrder(Order order)
        {
            if (order.Type == OrderType.BuyComputer)
            {
                Computer computer = null;
                switch (order.ComputerType)
                {
                    case ComputerType.Gaming:
                        computer = new Computer(GamingPCFactory.Instance);
                        break;
                    case ComputerType.Home:
                        computer = new Computer(HomePCFactory.Instance);
                        break;
                    case ComputerType.Office:
                        computer = new Computer(OfficePCFactory.Instance);
                        break;
                }
                return computer.ShowSpecs();
            }
            else
                return successor.ProcessOrder(order);
        }
    }
}
