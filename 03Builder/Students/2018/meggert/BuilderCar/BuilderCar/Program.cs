using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("HPI", "Bezszczotkowy", Type.Ofroad, "2S");
            car.Show();
            CarBuilder carBuild = new CarBuilder();

            Car car2 = carBuild.CreateCar("Traxxas").InsertEngine("Szczotkowy").InsertTypeCar(Type.Buggy).InsertBattery("3S");
            car2.Show();

            Car car3 = carBuild.CreateCar("HSP").InsertEngine("Bezszczotkowy").InsertTypeCar(Type.Onroad).InsertBattery("6S");
            car3.Show();


            Console.ReadKey();
        }
    }
}
