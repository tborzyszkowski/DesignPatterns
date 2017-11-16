using System;

namespace BuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit marine = new MarineBuilder().SetName("Marine_1")
                                             .SetArmorPoints(5)
                                             .SetAttackPoints(7)
                                             .SetHealthPoints(10)
                                             .SetSize(1);

            marine.PrintInfo();
            Console.ReadKey();
        }
    }
}
