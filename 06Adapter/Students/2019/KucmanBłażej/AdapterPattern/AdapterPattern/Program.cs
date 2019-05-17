using AdapterPattern.ex1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using AdapterPattern.ex2;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercises 1 //////////////////
            Console.WriteLine("Experiment 1: test the aircraft engine");
            IAircraft aircraft = new Aircraft();
            aircraft.TakeOff();
            if (aircraft.Airborne) Console.WriteLine(
                 "The aircraft engine is fine, flying at "
                 + aircraft.Height + "meters");

            // Classic usage of an adapter
            Console.WriteLine("\nExperiment 2: Use the engine in the Seabird");
            IAircraft seabird = new Seabird(new Aircraft());
           // IAircraft seabird = new Seabird();
            seabird.TakeOff(); // And automatically increases speed
            Console.WriteLine("The Seabird took off");

            // Two-way adapter: using seacraft instructions on an IAircraft object
            // (where they are not in the IAircraft interface)
            Console.WriteLine("\nExperiment 3: Increase the speed of the Seabird:");
            (seabird as ISeacraft).IncreaseRevs();
            (seabird as ISeacraft).IncreaseRevs();
            if (seabird.Airborne)
                Console.WriteLine("Seabird flying at height " + seabird.Height +
                    " meters and speed " + (seabird as ISeacraft).Speed + " knots");
            Console.WriteLine("Experiments successful; the Seabird flies!");
            /////////////////////////////////////////////////////////////////////////////////////
            ///
            // zad2 
            Console.WriteLine("\nZADANIE 2\n");
            Console.WriteLine("CesarEncryption");
            var encryption1 = new AdapterEncryption(new CesarChipper());
            Console.WriteLine(encryption1.Encryption("kokoJAMBO"));

            Console.WriteLine("\nSwapEncryption");
            var encryption2 = new AdapterEncryption(new Swap());
            Console.WriteLine(encryption2.Encryption("kokoJAMBO"));

            Console.WriteLine("\nToUpper");
            encryption2.ChangeRequest(s => $"{s.ToUpper()}");
            Console.WriteLine(encryption2.Encryption("kokoJAMBO"));

            Console.WriteLine("\nSHA256");
            encryption2.ChangeRequest(Sha256.ComputeSha256Hash);
            Console.WriteLine(encryption2.Encryption("kokoJAMBO"));

        }
    }
}
