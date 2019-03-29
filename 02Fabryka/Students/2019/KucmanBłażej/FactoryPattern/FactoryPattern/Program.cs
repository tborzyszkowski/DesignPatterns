using FactoryPattern.Reflection;
using FactoryPattern.SimpleFactory;
using FactoryPattern.NoReflection;
using FactoryPattern.SimpleFactory.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.AbstractFactory;
using FactoryPattern.FactoryMethodC;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10_000_000;
            double[] times = new double[5];
            TimeSpan roznica;
            DateTime startTime, stopTime;

            var simpleFactory = WehicleFactory.Instance;
            Car car;
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                car = simpleFactory.CreateCar("SmallCar");
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[0] = roznica.TotalMilliseconds;

            startTime = DateTime.Now;
            WehicleFactoryFM factoryMethod = PolandFactory.Instance;
            for (int i = 0; i < n; i++)
            {
                car = factoryMethod.MakeCar("SmallCar") as Car;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[1] = roznica.TotalMilliseconds;

            AbstractFactory.AbstarctFactory abstractFactory = new FactoryFA(PolandFactoryAF.Instance);
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                car = abstractFactory.CreateCar() as Car;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[2] = roznica.TotalMilliseconds;

            WehicleFactoryNoReflection wehicleFactoryNoReflection = WehicleFactoryNoReflection.Instance;
            wehicleFactoryNoReflection.RegisterProduct("SmallCar", typeof(SmallCar));
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                car = wehicleFactoryNoReflection.CreateWehicle("SmallCar") as Car;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[3] = roznica.TotalMilliseconds;

            WehicleFactoryReflection wehicleFactoryReflection = WehicleFactoryReflection.Instance;
            wehicleFactoryReflection.RegisterProduct();
            
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                car = wehicleFactoryReflection.CreateWehicle("SmallCar") as Car;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[4] = roznica.TotalMilliseconds;

            Console.WriteLine("SimpleFactory: " + times[0] + " ms");
            Console.WriteLine("FactoryMethod: " + times[1] + " ms");
            Console.WriteLine("AbstractFactory: " + times[2] + " ms");
            Console.WriteLine("NoReflection: " + times[3] + " ms");
            Console.WriteLine("Reflection: " + times[4] + " ms");
            Console.ReadKey();
        }
    }
}
