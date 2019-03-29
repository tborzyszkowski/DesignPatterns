using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Trucks
{
    public class Scania : Truck
    {
        public Scania()
        {
            Name = "R450";
            Price = 279900;
            Speed = 90;
            Horsepower = 450;
            FuelTank = 700;

        }
        public new void getSound()
        {
            Console.WriteLine("Whrrummmmm");
        }
    }
}
