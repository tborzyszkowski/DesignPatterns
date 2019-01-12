using AbstractFactory.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class Package
    {
        Laptop laptop;
        MobilePhone phone;
        Televisor tv;

        public Package(IPackageFactory factory)
        {
            laptop = factory.CreateLaptop();
            phone = factory.CreatePhone();
            tv = factory.CreateTelevisor();
            GetInfo();
        }

        public void GetInfo()
        {
            Console.WriteLine(laptop.GetBrand());
        }
    }
}
