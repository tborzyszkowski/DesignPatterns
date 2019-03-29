using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Trucks
{
    public class Volfik : Truck
    {
        public Volfik()
        {
            Name = "FH500";
            Price = 227900;
            Speed = 90;
            Horsepower = 500;
            FuelTank = 800;

        }
        public new void getSound()
        {
            Console.WriteLine("Whrrummmmm");
        }
    }
}
