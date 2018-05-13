using System;

namespace Seabird
{
    public class Program
    {
        public static void Main()
        {
            // Classic usage of an adapter
            Console.WriteLine("\nExperiment 1: Use the engine in the Seabird");
            IAircraft seabird = new Seabird();
            seabird.TakeOff(); // And automatically increases speed
            Console.WriteLine("The Seabird took off");

            // Two-way adapter: using seacraft instructions on an IAircraft object
            // (where they are not in the IAircraft interface)
            Console.WriteLine("\nExperiment 1.5: Increase the speed of the Seabird:");
            (seabird as ISeacraft).IncreaseRevs();
            (seabird as ISeacraft).IncreaseRevs();
            if (seabird.Airborne)
                Console.WriteLine("Seabird flying at height " + seabird.Height +
                    " meters and speed " + (seabird as ISeacraft).Speed + " knots");
            Console.WriteLine("Experiments successful; the Seabird flies!");

            Console.WriteLine("\nExperiment 2: Increase the speed of the Seabird2:");
            ISeacraft seabird2 = new SeabirdToAircraft();
            seabird2.IncreaseRevs();
            seabird2.IncreaseRevs();
            Console.WriteLine($"Seabird2 has speed {seabird2.Speed} knots");

            Console.WriteLine("\nExperiment 2.5: Use the engine in the Seabird2");
            (seabird2 as IAircraft).TakeOff();
            Console.WriteLine("The Seabird2 took off");
            if ((seabird2 as IAircraft).Airborne)
                Console.WriteLine("Seabird2 flying at height " + (seabird2 as IAircraft).Height +
                    " meters and speed " + seabird2.Speed + " knots");
            Console.WriteLine("Experiments successful; the Seabird2 flies!");

            Console.ReadKey();
        }
    }
}
