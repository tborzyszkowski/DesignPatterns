using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.SimpleFactory.Cars;
using FactoryPattern.SimpleFactory.Tractors;
using FactoryPattern.SimpleFactory.Trucks;

namespace FactoryPattern.AbstractFactory
{
    public class PolandFactoryAF : IFactory
    {
        private static Lazy<PolandFactoryAF> instanceWehicle = new Lazy<PolandFactoryAF>(CreateInstance);

        private static PolandFactoryAF CreateInstance()
        {
            return Activator.CreateInstance(typeof(PolandFactoryAF), true) as PolandFactoryAF;
        }
        public static PolandFactoryAF Instance
        {
            get { return instanceWehicle.Value; }
        }

        public Car CreateCar()
        {
            return new SuperCar();
        }

        public Tractor CreateTractor()
        {
            return new BigBud();
        }

        public Truck CreateTruck()
        {
            return new Mac();
        }
    }
}
