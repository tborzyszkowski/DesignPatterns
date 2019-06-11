using System;
using ComputerShop.Model.Employees;
using ComputerShop;
using ComputerShop.Model;

namespace ComputerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            WarehouseWorker warehouseWorker = new WarehouseWorker();
            warehouseWorker.SetSuccessor(manager);
            ShopWorker shopWorker = new ShopWorker();
            shopWorker.SetSuccessor(warehouseWorker);

            Console.WriteLine(shopWorker.ProcessOrder(new Order(OrderType.BuyComputer, ComputerType.Gaming)));
            Console.WriteLine(shopWorker.ProcessOrder(new Order(OrderType.Warranty)));
            Console.WriteLine(shopWorker.ProcessOrder(new Order(OrderType.Complaint)));

            Console.ReadKey();
        }
    }
}
