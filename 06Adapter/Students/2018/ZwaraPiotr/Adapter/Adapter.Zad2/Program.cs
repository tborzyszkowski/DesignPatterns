using System;

namespace Adapter.Zad2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var adapter1 = new AnimalAdapeter(new PenguinTarget());
            Console.WriteLine(adapter1.TryFly());

            var adapter2 = new AnimalAdapeter(new AnimalAdaptee { Name = "Bat" });
            Console.WriteLine(adapter2.TryFly());

            adapter2.ChangeRequest(() => "Bat broke his wing and can't fly anymore");
            Console.WriteLine(adapter2.TryFly());

            Console.ReadKey();
        }
    }
}
