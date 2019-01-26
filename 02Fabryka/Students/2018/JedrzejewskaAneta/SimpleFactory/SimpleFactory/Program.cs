using SimpleFactory.Product;
using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop laptop = SimpleFactory.NewLaptop("Ideapad");

            MobilePhone phone = SimpleFactory.NewMobilePhone("Galaxy");

            Televisor televisor = SimpleFactory.NewTelevisor("LG");

            Console.WriteLine(laptop.GetBrand());
            Console.WriteLine(phone.GetBrand());
            Console.WriteLine(televisor.GetBrand());

            Console.ReadKey();
        }
    }
}
