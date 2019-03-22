//Jan Bienias 238201

/*
0. Klient potrzebuje obiekty należące do kilku (3-4) rodzajów produktów.
    -Każdy rodzaj posiada kilka (5-6) konkretnych realizacji.
    -Wymyślić i wytworzyć kod opisujący produkty i ich rodzaje.

1. Dla rozdzielenia procesu wytwarzania obiektów od klas klienta zastosować fabrykę zaimplementowaną jako singleton. Zaprezentować pozytywne i negatywne skutki zastosowania:
    -fabryki prostej
    -fabryki z metodą wytwórczą
    -fabryki abstrakcyjnej

2. Porównać złożoność i efektywność działania fabryk z punktu 1. z fabryką używającą rejestracji klas z wykorzystaniem refleksji oraz bez wykorzystania refleksji
*/

//Źródła:
//Head First Design Pattern
//https://www.youtube.com/watch?v=JEk7B_GUErc
//https://refactoring.guru/design-patterns/factory-method
//https://refactoring.guru/design-patterns/abstract-factory

using Factory.AbstractFactory;
using Factory.ClassRegistrationFactory.NoReflection;
using Factory.ClassRegistrationFactory.Reflection;
using Factory.FactoryMethod;
using Factory.MilitaryVehicles;
using Factory.MilitaryVehicles.Tanks;
using System;
using System.Diagnostics;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10_000_000;
            //Test efektywnosci
            //Sprawdzamy czas jaki zajmie poszczegolnym metodom na utworzenie obiektu n razy
            //Chcemy cały czas tworzyc czołg typu Churchil()
            Console.WriteLine(n + " iterations for each method...");
            var watch = new Stopwatch();
            double[] times = new double[6];
            string[] methodNames = new string[6] { "SimpleFactory", "FactoryMethod", "AbstractFact.", "NoReflection", "Generic", "Reflection" };

            IMilitaryVehicle tank;
            //A. SimpleFactory
            var simpleFactory = SimpleFactory.SimpleFactory.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                tank = simpleFactory.CreateTank("Churchill");
            }
            watch.Stop();
            times[0] = watch.ElapsedMilliseconds;
            watch.Reset();

            //B. FactoryMethod
            var factory = TankFactory.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                tank = factory.Build("Churchill");
            }
            watch.Stop();
            times[1] = watch.ElapsedMilliseconds;
            watch.Reset();

            //C. AbstractFactory
            var abstractFactoryClient = UKFactorySet.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                tank = abstractFactoryClient.CreateTank();
            }
            watch.Stop();
            times[2] = watch.ElapsedMilliseconds;
            watch.Reset();

            //D. Fabryka z rejestracją klas (bez refleksji)
            var noReflectionTankFactory = NoReflectionFactory.Instance;
            noReflectionTankFactory.RegisterTank("Churchill", typeof(Churchill));
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                tank = noReflectionTankFactory.CreateTank("Churchill");
            }
            watch.Stop();
            times[3] = watch.ElapsedMilliseconds;
            watch.Reset();

            //E. Fabryka generyczna (bez refleksji)
            noReflectionTankFactory = NoReflectionFactory.Instance;
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                tank = noReflectionTankFactory.CreateTank<Churchill>();
            }
            watch.Stop();
            times[4] = watch.ElapsedMilliseconds;
            watch.Reset();

            //F. Fabryka z rejestracją klas (z refleksją)
            var reflectionTankFactory = ReflectionFactory.Instance;
            reflectionTankFactory.RegisterTanks();
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                tank = reflectionTankFactory.CreateTank("Churchill");
            }
            watch.Stop();
            times[5] = watch.ElapsedMilliseconds;
            watch.Reset();

            Console.WriteLine("Method: \t time");
            for (int i = 0; i < times.Length; i++)
            {
                Console.WriteLine(methodNames[i] + ":\t " + times[i] + " ms");
            }
        }
    }
}
