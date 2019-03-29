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
    public abstract class AbstarctFactory
    {
        private readonly IFactory factory;

        protected AbstarctFactory(IFactory factory)
        {
            this.factory = factory;
        }
        public Car CreateCar()
        {
            return factory.CreateCar();
        }
        public Tractor CreateTractor()
        {
            return factory.CreateTractor();
        }
        public Truck CreateTruck()
        {
            return factory.CreateTruck();
        }
    }
}
