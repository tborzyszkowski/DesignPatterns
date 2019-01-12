using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactory.Product;
using AbstractFactory.Product.Computer;
using AbstractFactory.Product.Smartphone;
using AbstractFactory.Product.TV;

namespace AbstractFactory
{
    class LGPackageFactory : IPackageFactory
    {
        public Laptop CreateLaptop()
        {
            return new Gram();
        }

        public MobilePhone CreatePhone()
        {
            return new ThinQ();
        }

        public Televisor CreateTelevisor()
        {
            return new LG();
        }

        string GetInfo()
        {
            return "LG";
        }
    }
}
