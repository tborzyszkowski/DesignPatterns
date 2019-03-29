using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Tractors
{
    class Lambo : Tractor
    {
        public Lambo()
        {
            Name = "Spark 130";
            Price = 260000;
            Speed = 40;
            Horsepower = 120;
            LiftingCapacity = 5000;

        }
        public new void getSound()
        {
            Console.WriteLine("Phyrrrrrrr phyrrrrr");
        }
    }
}
