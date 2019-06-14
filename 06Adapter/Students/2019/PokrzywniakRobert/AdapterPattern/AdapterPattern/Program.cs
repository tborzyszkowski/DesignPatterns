using AdapterPattern.Zad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using AdapterPattern.Zad2;

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
            Console.WriteLine("ReadFromFile");
            var points1 = new AdapterPoints(new ReadFromFile());
            PrintPoints(points1.Points);

            Console.WriteLine("\nReadFromString");
            var points2 = new AdapterPoints(new ReadFromString());
            PrintPoints(points2.Points);

            Console.WriteLine("\nGenerateRandom");
            points2.ChangeRequest(GenerateRandom.GetPoints());
            PrintPoints(points2.Points);
            Console.ReadLine();
        }
        public static void PrintPoints(IList<Point> points)
        {
            foreach(var point in points)
            {
                Console.WriteLine("X: " + point.X + ", Y: " + point.Y);
            }
        }
    }
}
