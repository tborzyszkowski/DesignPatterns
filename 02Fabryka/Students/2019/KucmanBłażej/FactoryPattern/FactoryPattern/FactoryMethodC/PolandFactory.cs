using FactoryPattern.SimpleFactory;
using FactoryPattern.SimpleFactory.Cars;
using FactoryPattern.SimpleFactory.Tractors;
using FactoryPattern.SimpleFactory.Trucks;
using System;

namespace FactoryPattern.FactoryMethodC
{
    public class PolandFactory : WehicleFactoryFM
    {
        private static Lazy<PolandFactory> instanceWehicle = new Lazy<PolandFactory>(CreateInstance);

        private static PolandFactory CreateInstance()
        {
            return Activator.CreateInstance(typeof(PolandFactory), true) as PolandFactory;
        }
        public static PolandFactory Instance
        {
            get { return instanceWehicle.Value; }
        }
        protected override IWehicle CreateCar(string car)
        {
            switch (car)
            {
                
                case "SuperCar":
                    return new SuperCar() as Car;
                case "SmallCar":
                    return new SmallCar() as Car;
                case "MediumCar":
                    return new MediumCar() as Car;
                case "HighClasCar":
                    return new HighClasCar() as Car;
                case "SlowCar":
                    return new SlowCar() as Car;
                default:
                    return null;

            }
        }

        protected override IWehicle CreateTractor(string tractor)
        {
            switch (tractor)
            {
                case "Rusek":
                    return new Rusek() as Tractor;
                case "BigBud":
                    return new BigBud() as Tractor;
                case "C360":
                    return new C360() as Tractor;
                case "Lambo":
                    return new Lambo() as Tractor;
                case "Zetor":
                    return new Zetor() as Tractor;
                default:
                    return null;
            }
        }

        protected override IWehicle CreateTruck(string truck)
        {
            switch (truck)
            {
                case "Dafik":
                    return new Dafik() as Truck;
                case "Mac":
                    return new Mac() as Truck;
                case "Renaulek":
                    return new Renaulek() as Truck;
                case "Scania":
                    return new Scania() as Truck;
                case "Volfik":
                    return new Volfik() as Truck;
                default:
                    return null;
            }
        }
    }
}
