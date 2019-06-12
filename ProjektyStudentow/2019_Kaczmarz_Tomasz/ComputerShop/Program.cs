using System;
using ComputerShop.Model.Employees;
using ComputerShop.Adapter;
using ComputerShop.Model;

namespace ComputerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            Console.WriteLine(shop.TakeOrder(new Order(OrderType.BuyComputer, ComputerType.Home)));
            Console.WriteLine(shop.TakeOrder(new Order(OrderType.Warranty)));
            Console.WriteLine(shop.TakeOrder(new Order(OrderType.Complaint)));

            Console.ReadKey();
        }
    }
}
