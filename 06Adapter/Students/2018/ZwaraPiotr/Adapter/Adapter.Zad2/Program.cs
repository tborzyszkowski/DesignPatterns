using System;

namespace Adapter.Zad2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var adapter1 = new FlyingAnimalAdapter(new PenguinAdaptee());
            Console.WriteLine(adapter1.Fly());

            var adapter2 = new FlyingAnimalAdapter(new SquirrelAdaptee());
            Console.WriteLine(adapter2.Fly());

            adapter2.ChangeTryFy(() => "Squirrel drank red bull and learned to fly");
            Console.WriteLine(adapter2.Fly());

            Console.ReadKey();
        }
    }
}
