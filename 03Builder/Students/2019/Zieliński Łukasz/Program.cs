using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Frigates;
using Builder.Abstract;
using Builder.Builder1;
using Builder.Builder2;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {

            int m = 10000000; // 10 mln
            //int n = 8000;
            int n = 1000;
            //TestBuilderOverFactory(n);
            Console.WriteLine();
            TestFactoryOverBuilder(m);
        }
            
        static void TestBuilderOverFactory(int n)
        {
            double[] times = new double[5];
            TimeSpan roznica;
            DateTime startTime, stopTime;
            Ships ship;
            //  AbstractFactory
            AbstractFactory abstractFactory = new Abstract1(EarthAbstractFactory.Instance);
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                ship = abstractFactory.CreateFrigate() as Ships;
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[0] = roznica.TotalMilliseconds;

            // Builder
            var constructor1 = new Constructor1();
            startTime = DateTime.Now;
            for (int i = 0; i < n; i++)
            {
                Builder1.Frigate1 builder1 = constructor1.Constructor(new Cobalt1());
            }
            stopTime = DateTime.Now;
            roznica = stopTime - startTime;
            times[1] = roznica.TotalMilliseconds;
            Console.WriteLine("Porównanie czasu tworzenia obiektów przez fabryke i Builder:");
            Console.WriteLine("Abstract Factory: " + times[0] + " ms");
            Console.WriteLine("Builder1:         " + times[1] + " ms");
            Console.WriteLine("-------------------------------------------------");
            
        }
            static void TestFactoryOverBuilder(int m)
            {
            double[] times = new double[5];
            TimeSpan roznica;
            DateTime startTime, stopTime;
            Ships ship;
            //  AbstractFactory
            AbstractFactory abstractFactory1 = new Abstract1(EarthAbstractFactory.Instance);
                startTime = DateTime.Now;
                for (int i = 0; i < m; i++)
                {
                    ship = abstractFactory1.CreateFrigate() as Ships;
                }
                stopTime = DateTime.Now;
                roznica = stopTime - startTime;
                times[2] = roznica.TotalMilliseconds;

                // Builder1
                var constructor11 = new Constructor1();
                startTime = DateTime.Now;
                for (int i = 0; i < m; i++)
                {
                    Builder1.Frigate1 builder1 = constructor11.Constructor(new Cobalt1());
                }
                stopTime = DateTime.Now;
                roznica = stopTime - startTime;
                times[3] = roznica.TotalMilliseconds;
            Console.WriteLine("Porównanie czasu tworzenia obiektów przez fabryke i Builder:");
            Console.WriteLine("Abstract Factory: " + times[2] + " ms");
            Console.WriteLine("Builder2:         " + times[3] + " ms");
            //Console.ReadKey();
        }
           
    }
}
