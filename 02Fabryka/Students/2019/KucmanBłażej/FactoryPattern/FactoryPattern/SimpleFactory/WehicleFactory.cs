using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.SimpleFactory.Cars;
using FactoryPattern.SimpleFactory.Tractors;
using FactoryPattern.SimpleFactory.Trucks;

namespace FactoryPattern.SimpleFactory
{
    public class WehicleFactory
    {
        private static Lazy<WehicleFactory> instanceWehicle = new Lazy<WehicleFactory>(CreateInstance);

        private static WehicleFactory CreateInstance()
        {
            return Activator.CreateInstance(typeof(WehicleFactory), true) as WehicleFactory;
        }
        public static WehicleFactory Instance
        {
            get { return instanceWehicle.Value; }
        }

        public Car CreateCar(string car)
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
        public Tractor CreateTractor(string tractor)
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
        public Truck CreateTruck(string truck)
        {
            switch (truck) {
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
