using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Trucks
{
    public class Dafik : Truck
    {
        public Dafik()
        {
            Name = "XF";
            Price = 105000;
            Speed = 90;
            Horsepower = 460;
            FuelTank = 430;

        }
        public new void getSound()
        {
            Console.WriteLine("Whrrum");
        }
    }
}
