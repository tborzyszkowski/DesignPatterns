using System;

using Adapter.Zad1.Abstraction;
using Adapter.Zad1.Implementation;

namespace Adapter.Zad1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Experiment 1: test the aircraft engine");
            IAircraft aircraft = new Aircraft();
            aircraft.TakeOff();
            if (aircraft.Airborne)
                Console.WriteLine($"The aircraft engine is fine, flying at{aircraft.Height} meters");


            foreach (IAircraft seabird in new IAircraft[] { new Seabird(), new Seabird_NEW(new Aircraft()) })
            {
                // Classic usage of an adapter
                Console.WriteLine("\nExperiment 2: Use the engine in the Seabird");
                seabird.TakeOff(); // And automatically increases speed
                Console.WriteLine("The Seabird took off");

                // Two-way adapter: using seacraft instructions on an IAircraft object
                // (where they are not in the IAircraft interface)
                Console.WriteLine("\nExperiment 3: Increase the speed of the Seabird:");
                (seabird as ISeacraft).IncreaseRevs();
                (seabird as ISeacraft).IncreaseRevs();
                if (seabird.Airborne)
                    Console.WriteLine($"Seabird flying at height {seabird.Height} meters and speed {(seabird as ISeacraft).Speed} knots");

                Console.WriteLine("Experiments successful; the Seabird flies!");
            }

            Console.ReadKey();
        }
    }
}
