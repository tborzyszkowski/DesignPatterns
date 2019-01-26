using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactory.Product;
using AbstractFactory.Product.Computer;
using AbstractFactory.Product.Smartphone;
using AbstractFactory.Product.TV;

namespace AbstractFactory
{
    class SonyPackageFactory : IPackageFactory
    {
        public Laptop CreateLaptop()
        {
            return new SVF();
        }

        public MobilePhone CreatePhone()
        {
            return new Xperia();
        }

        public Televisor CreateTelevisor()
        {
            return new Sony();
        }
        string GetInfo()
        {
            return "Sony";
        }
    }
}
