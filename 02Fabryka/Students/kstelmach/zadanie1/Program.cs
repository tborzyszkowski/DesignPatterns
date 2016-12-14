using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zadanie1;

namespace _02Fabryka
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleCarFactory factory = new SimpleCarFactory();
            CarStore store = new CarStore(factory);

            Car car = store.OrderCar("audi");
            Console.WriteLine("We ordered a " + car.GetName() + "\n");
            Console.WriteLine(car.CarInfo());

            Car car2 = store.OrderCar("bmw");
            Console.WriteLine("We ordered a " + car2.GetName() + "\n");
            Console.WriteLine(car2.CarInfo());

            Console.ReadLine();
        }
    }
}
