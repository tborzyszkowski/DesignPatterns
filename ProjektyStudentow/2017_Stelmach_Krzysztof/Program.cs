using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    /*
     * Krzysztof Stelmach Projekt na wzorce projektowe 2017
     * Wzorce: Prototype, Factory i Proxy
    */
    class Program
    {
        static void Main(string[] args)
        {
          
            CarManager carmanager = new CarManager();
            SimpleFactory factory = new SimpleFactory();

            factory.CreateTypes();

            TestDriveProxy testDriveProxy = new TestDriveProxy();

            carmanager["testowy"] = new Car("Mercedes", "CLS", "Yellow", "sedan");

            Car testowy = carmanager["testowy"].Clone() as Car;

            testDriveProxy.ReserveTestDrive(testowy);
            testDriveProxy.GoToTestDrive(testowy);
            testDriveProxy.RateAfterTestDrive(testowy, 10);

            Store store = new Store(factory);

            store.OrderCar("miejski");
            store.OrderCar("terenowy");
            store.OrderCar("sportowy");

            Console.ReadKey();
        }
    }
}
