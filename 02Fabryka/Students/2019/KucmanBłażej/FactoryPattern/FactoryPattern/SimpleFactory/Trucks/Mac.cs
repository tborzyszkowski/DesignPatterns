using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Trucks
{
    public class Mac : Truck
    {
        public Mac()
        {
            Name = "Titan";
            Price = 588000;
            Speed = 168;
            //Horsepower = 600;
            FuelTank = 1000;

        }
        public new void getSound()
        {
            Console.WriteLine("Whrrrrum Whruuuuuuuuuum");
        }
    }
}
