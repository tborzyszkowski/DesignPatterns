using System;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Save.GetInstance("Aneta", new Forest(new Player("ExampleName", WeaponType.Axe))).ToString());
            Console.ReadKey();

        }
    }
}
