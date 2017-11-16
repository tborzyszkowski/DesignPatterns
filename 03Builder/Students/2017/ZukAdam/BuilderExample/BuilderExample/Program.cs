using System;

namespace BuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit marine = UnitsFactory.CreateUnit(new MarineBuilder());

            marine.PrintInfo();

            Console.WriteLine("---------------------");

            Unit tank = UnitsFactory.CreateUnit(new TankBuilder());

            tank.PrintInfo();

            Console.ReadKey();
        }
    }
}
