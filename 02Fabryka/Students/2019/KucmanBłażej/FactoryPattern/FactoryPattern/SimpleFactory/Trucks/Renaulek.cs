using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Trucks
{
    public class Renaulek : Truck
    {
        public Renaulek()
        {
            Name = "Premium";
            Price = 182900;
            Speed = 90;
            Horsepower = 460;
            FuelTank = 800;

        }
        public new void getSound()
        {
            Console.WriteLine("Whrrrrum");
        }
    }
}
