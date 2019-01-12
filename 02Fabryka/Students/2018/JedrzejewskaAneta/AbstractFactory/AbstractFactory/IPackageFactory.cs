using AbstractFactory.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    interface IPackageFactory
    {
        Laptop CreateLaptop();
        MobilePhone CreatePhone();
        Televisor CreateTelevisor();
        
    }
}
