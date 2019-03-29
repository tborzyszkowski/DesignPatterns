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
    public class ChinaFactoryAF : IFactory
    {
        private static Lazy<ChinaFactoryAF> instanceWehicle = new Lazy<ChinaFactoryAF>(CreateInstance);

        private static ChinaFactoryAF CreateInstance()
        {
            return Activator.CreateInstance(typeof(ChinaFactoryAF), true) as ChinaFactoryAF;
        }
        public static ChinaFactoryAF Instance
        {
            get { return instanceWehicle.Value; }
        }
        public Car CreateCar()
        {
            return new SlowCar();
        }

        public Tractor CreateTractor()
        {
            return new Rusek();
        }

        public Truck CreateTruck()
        {
            return new Dafik();
        }
    }
}
