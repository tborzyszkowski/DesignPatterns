using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {

            Car2 prototyp = new Car2();
            prototyp.obj.Battery = "2S";
            prototyp.Creating.Company = "HPI";
            prototyp.Creating.Engine = "szczotkowy";

            Car2 prototyp2 = new Car2();
            prototyp2 = prototyp.DeepCopy();


            if (Object.ReferenceEquals(prototyp.obj, prototyp2.obj))
                Console.WriteLine("ten sam obiekt");
            else
                Console.WriteLine("inny obiekt");

            Console.ReadKey();

        }
    }
}
