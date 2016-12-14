using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    public class CarStore
    {
        SimpleCarFactory factory;

        public CarStore(SimpleCarFactory factory)
        {
            this.factory = factory;
        }

        public Car OrderCar(string brand)
        {
            Car car;
            car = factory.CreateCar(brand);
            car.Create();

            return car;
        }

    }
}
