using FactoryPattern.SimpleFactory.Cars;
using FactoryPattern.SimpleFactory.Tractors;
using FactoryPattern.SimpleFactory.Trucks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.AbstractFactory
{
    public interface IFactory
    {
        Car CreateCar();
        Tractor CreateTractor();
        Truck CreateTruck();
    }
}
