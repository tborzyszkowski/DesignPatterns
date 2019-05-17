using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Factory.Method;
using Factory.Abstract;
using Factory.ClassRegistration;
using Factory.Frigates;
using Factory.CapitalShips;
using Factory.Cruisers;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000; // 1 mln
            double[] times = new double[5];
            TimeSpan roznica;
            DateTime startTime, stopTime;

            var simpleFactory = SimpleFactory.Instance;
            Ships ship;
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                ship = simpleFactory.CreateFrigate("cobalt");
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[0] = roznica.TotalMilliseconds;

            //------------------------------------------------------------------------------

            startTime = DateTime.Now;
            MethodFactory methodFactory = EarthFactory.Instance;
            for (int i = 0; i < n; i++)
            {
                ship = methodFactory.BuildFrigate("cobalt") as Ships;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[1] = roznica.TotalMilliseconds;

            //------------------------------------------------------------------------------

            AbstractFactory abstractFactory = new Abstract1(EarthAbstractFactory.Instance);
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                ship = abstractFactory.CreateFrigate() as Ships;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[2] = roznica.TotalMilliseconds;

            //------------------------------------------------------------------------------

            
            RegistrationFactory registrationFactory = RegistrationFactory.Instance;
            registrationFactory.BuildShip("cobalt", typeof(Frigate));
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                ship = abstractFactory.CreateFrigate() as Ships;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[3] = roznica.TotalMilliseconds;

            //------------------------------------------------------------------------------

            RegistrationFactoryWithReflection reflectionFactory = RegistrationFactoryWithReflection.Instance;
            reflectionFactory.BuildShip();
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                ship = abstractFactory.CreateFrigate() as Ships;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[4] = roznica.TotalMilliseconds;


            Console.WriteLine("Porównanie czasu tworzenia obiektów przez fabryki:");
            Console.WriteLine("Simple Factory: " + times[0] + " ms");
            Console.WriteLine("Factory Method: " + times[1] + " ms");
            Console.WriteLine("Abstract Factory: " + times[2] + " ms");
            Console.WriteLine("\nZ rejertracją klas:");
            Console.WriteLine("NoReflection: " + times[3] + " ms");
            Console.WriteLine("Reflection: " + times[4] + " ms");
            Console.ReadKey();
        }
    }
}
