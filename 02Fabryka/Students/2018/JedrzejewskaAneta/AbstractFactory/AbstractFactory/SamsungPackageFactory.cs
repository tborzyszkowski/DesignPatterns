using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactory.Product;
using AbstractFactory.Product.Computer;
using AbstractFactory.Product.Smartphone;
using AbstractFactory.Product.TV;

namespace AbstractFactory
{
    class SamsungPackageFactory : IPackageFactory
    {
        public Laptop CreateLaptop()
        {
            return new Series();
        }

        public MobilePhone CreatePhone()
        {
            return new Galaxy();
        }

        public Televisor CreateTelevisor()
        {
            return new Samsung();
        }
        string GetInfo()
        {
            return "Samsung";
        }
    }
}
