using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactory.Product;
using AbstractFactory.Product.Computer;
using AbstractFactory.Product.Smartphone;
using AbstractFactory.Product.TV;

namespace AbstractFactory
{
    class HPPackageFactory : IPackageFactory
    {
        public Laptop CreateLaptop()
        {
            return new Omen();
        }

        public MobilePhone CreatePhone()
        {
            return new Elite();
        }

        public Televisor CreateTelevisor()
        {
            return new HP();
        }

        string GetInfo()
        {
            return "HP";
        }
    }
}
