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
            ShoesManager shoesmanager = new ShoesManager();

            shoesmanager["football"] = new Shoes("Red", 43.5f, "Nike");
            shoesmanager["Winter"] = new Shoes("Black", 43.5f, "Timberland");
            shoesmanager["Elegant"] = new Shoes("Brown", 43.5f, "Gino Rossi");


            Shoes shoes1 = shoesmanager["football"].Clone() as Shoes;
            Shoes shoes2 = shoesmanager["Winter"].Clone() as Shoes;
            Shoes shoes3 = shoesmanager["Elegant"].Clone() as Shoes;


            // Wait for user
            Console.ReadKey();
        }
    }
}
