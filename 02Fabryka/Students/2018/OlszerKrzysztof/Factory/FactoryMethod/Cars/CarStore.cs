using System;

namespace FactoryMethod.Cars
{
    public abstract class CarStore
    {
        public abstract Car createCar(string id);
        public Car drive(string id)
        {
            Car car = createCar(id);
            String res = car.prepare();
            res += car.getMaxSpeed();
            res += car.breakCar();
            Console.WriteLine(res);
            return car;
        }
    }
}
