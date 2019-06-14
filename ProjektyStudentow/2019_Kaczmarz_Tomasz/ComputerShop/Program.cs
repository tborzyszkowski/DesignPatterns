using ComputerShop.Model;
using ComputerShop.Strategy;
using System;

namespace ComputerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(OrderType.BuyComputer, 3500);
            Shop shop = new Shop(new BudgetStrategy());
            Console.WriteLine(shop.TakeOrder(order));

            order = new Order(OrderType.BuyComputer, ComputerType.Gaming);
            shop = new Shop(new TypeStrategy());
            Console.WriteLine(shop.TakeOrder(order));

            order = new Order(OrderType.Warranty);
            Console.WriteLine(shop.TakeOrder(order));
            order = new Order(OrderType.Complaint);
            Console.WriteLine(shop.TakeOrder(order));

            Console.ReadKey();
        }
    }
}
