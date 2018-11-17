using System;
using AbstractFactory.Model;

namespace AbstractFactory
{
    public abstract class VehicleFactory
    {
        public abstract BaseVehicle Factory();
    }

    public class CarFactory : VehicleFactory
    {
        public override BaseVehicle Factory()
        {
            return Activator.CreateInstance<Car>();
        }
    }

    public class MotorbikeFactory : VehicleFactory
    {
        public override BaseVehicle Factory()
        {
            return Activator.CreateInstance<Motorbike>();
        }
    }

    public class BikeFactory : VehicleFactory
    {
        public override BaseVehicle Factory()
        {
            return Activator.CreateInstance<Bike>();
        }
    }
}
