//Zadanie 1
//Wzorując się na projektach 02VehicleBuilder i 03FluentBuilder zbudować własne buildery.
//Buildery powinny posiadać własność FluentInterface i wykorzystywać rzutowanie konkretnego 
//buildera na produkt (podobnie jak w projekcie 02VehicleBuilder). Język programowania dowolny.

//Zadanie 2
//Zbudować przykład problemu wytwarzania obiektów w aplikacji, 
//dla którego lepszym rozwiązaniem (wydajnościowo, komplikacja kodu, ...) będzie:
// - Wzorzec budowniczy(raczej niż fabryka abstrakcyjna)
// - Odwrotnie(fabryka abstrakcyjna raczej niż budowniczy)


//Źródła:
//https://www.youtube.com/watch?v=PBIM67J4RJQ


using Builder.BuilderOverFactory.AbstractFactory;
using Builder.BuilderOverFactory.FluentBuilder;
using Builder.FactoryOverBuilder.AbstractFactory;
using Builder.FactoryOverBuilder.FluentBuilder;
using System;
using System.Diagnostics;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100_000_000;
            TestBuilderOverFactory(n);
            Console.WriteLine();
            TestFactoryOverBuilder(n);
        }

        static void TestBuilderOverFactory(int iterations)
        {
            int n = iterations;
            Console.WriteLine("Test 'Builder over Factory', " + n + " iterations...");
            var watch = new Stopwatch();
            double[] times = new double[2];
            string[] methodNames = new string[2] { "Builder", "Abs. Factory" };
            BuilderOverFactory.FluentBuilder.Dodge dodgeFromBuilder;
            BuilderOverFactory.AbstractFactory.Dodge dodgeFromFactory;

            //Builder
            var dodgeCarDealer = new DodgeCarDealer();
            //var dodgeViperBuilder = new DodgeViperBuilder();
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                dodgeFromBuilder = dodgeCarDealer.Construct(new DodgeViperBuilder());
                //or:
                //dodgeFromBuilder = dodgeCarDealer.Construct(dodgeViperBuilder);
                //dodgeViperBuilder.CreateNewDodge(); //reset
            }
            watch.Stop();
            times[0] = watch.ElapsedMilliseconds;
            watch.Reset();

            //Abstract Factory
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                dodgeFromFactory = DodgeFactory.Instance.CreateDodge(1);
            }
            watch.Stop();
            times[1] = watch.ElapsedMilliseconds;
            watch.Reset();

            Console.WriteLine("Method: \t time");
            for (int i = 0; i < times.Length; i++)
            {
                Console.WriteLine(methodNames[i] + ":\t " + times[i] + " ms");
            }
        }

        static void TestFactoryOverBuilder(int iterations)
        {
            int n = iterations;
            Console.WriteLine("Test 'Factory Over Builder', " + n + " iterations...");
            var watch = new Stopwatch();
            double[] times = new double[2];
            string[] methodNames = new string[2] { "Builder", "Abs. Factory" };
            FactoryOverBuilder.FluentBuilder.MilitaryVehicles.Tanks.Tank tankFromBuilder;
            FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Tanks.Tank tankFromFactory;

            //Builder
            var tankFactory = new TankFactory();
            //var churchillTankBuilder = new ChurchillTankBuilder();
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                tankFromBuilder = tankFactory.Construct(new ChurchillTankBuilder());
                //or:
                //tankFromBuilder = tankFactory.Construct(churchillTankBuilder);
                //churchillTankBuilder.CreateNewTank(); //reset
            }
            watch.Stop();
            times[0] = watch.ElapsedMilliseconds;
            watch.Reset();

            //Abstract Factory
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                tankFromFactory = UKMilitaryVehicleFactory.Instance.CreateTank(1);
            }
            watch.Stop();
            times[1] = watch.ElapsedMilliseconds;
            watch.Reset();

            Console.WriteLine("Method: \t time");
            for (int i = 0; i < times.Length; i++)
            {
                Console.WriteLine(methodNames[i] + ":\t " + times[i] + " ms");
            }
        }
    }
}
