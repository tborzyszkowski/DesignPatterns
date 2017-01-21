using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Store
    {
        SimpleFactory factory;

        public Store(SimpleFactory factory)
        {
            this.factory = factory;
        }

        public Car OrderCar(string type)
        {
            Car car;
            car = factory.CreateCar(type);
            car.CarCreate();
            return car;
        }

    }
}
