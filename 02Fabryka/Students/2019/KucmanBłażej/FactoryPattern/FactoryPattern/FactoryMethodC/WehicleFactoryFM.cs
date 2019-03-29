using FactoryPattern.SimpleFactory;
using FactoryPattern.SimpleFactory.Cars;
using FactoryPattern.SimpleFactory.Tractors;
using FactoryPattern.SimpleFactory.Trucks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.FactoryMethodC
{
    public abstract class WehicleFactoryFM
    {
        protected abstract IWehicle CreateCar(string car);
        protected abstract IWehicle CreateTractor(string tractor);
        protected abstract IWehicle CreateTruck(string truck);

        public IWehicle MakeCar(string car)
        {
            return CreateCar(car);
        }
        public IWehicle MakeTractor(string tractor)
        {
            return CreateTractor(tractor);
        }
        public IWehicle MakeTruck(string truck)
        {
            return CreateTruck(truck);
        }

    }
}
