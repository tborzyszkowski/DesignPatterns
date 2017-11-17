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

            Console.WriteLine("---------------------");

            Unit testUnit = new TestUnitBuilder().SetName("TestName")
                                                 .SetAttackPoints(5)
                                                 .SetHealthPoints(13)
                                                 .SetArmorPoints(3)
                                                 .Build();

            testUnit.PrintInfo();

            Console.ReadKey();
        }
    }
}
