//Jan Bienias 238201

//Zadanie 1
//Wzorując się na projekcie ColorPrototype zaimplementować rozwiązanie umożliwiające
//tworzenie egzemplarzy obiektów na podstawie prototypów wymagających glębokiego kopiowania.

//Zadanie 2
//Wzorując się na projekcie DeepPrototype opracować przykład dla obiektów o większym
//zagłębieniu referencyjnym(np.: o zagłębieniu 3).


//Źródła:
//https://stackoverflow.com/questions/129389/how-do-you-do-a-deep-copy-of-an-object-in-net-c-specifically

using Prototype.DeepPrototype;
using System;
using System.Diagnostics;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 100_000;

            var restaurant = new Restaurant(new Kitchen(new Chef(new Assistant())));
            Console.WriteLine(n + " iterations for each method...");
            var watch = new Stopwatch();
            double[] times = new double[2];
            string[] methodNames = new string[2] { "DeepClone() using Serialization", "DeepClone() using Reflection   " };
            Restaurant clonedRestaurant;

            //A. DeepClone() using Serialization
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                clonedRestaurant = restaurant.DeepClone() as Restaurant;
            }
            watch.Stop();
            times[0] = watch.ElapsedMilliseconds;
            watch.Reset();

            //B. DeepClone() using Reflection
            watch.Start();
            for (int i = 0; i < n; i++)
            {
                clonedRestaurant = restaurant.DeepCloneByReflection() as Restaurant;
            }
            watch.Stop();
            times[1] = watch.ElapsedMilliseconds;
            watch.Reset();

            Console.WriteLine("METHOD: \t\t\t TIME:");
            for (int i = 0; i < times.Length; i++)
            {
                Console.WriteLine(methodNames[i] + ": " + times[i] + " ms");
            }
        }
    }
}
