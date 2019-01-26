using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactory.Product;
using AbstractFactory.Product.Computer;
using AbstractFactory.Product.Smartphone;
using AbstractFactory.Product.TV;

namespace AbstractFactory
{
    class ApplePackageFactory : IPackageFactory
    {
        public Laptop CreateLaptop()
        {
            return new MacBook();
        }

        public MobilePhone CreatePhone()
        {
            return new IPhone();
        }

        public Televisor CreateTelevisor()
        {
            return new Apple();
        }

        string GetInfo()
        {
            return "Apple";
        }
    }
}
