using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Tractors
{
    public class Zetor : Tractor
    {
        public Zetor()
        {
            Name = "5211";
            Price = 32000;
            Speed = 30;
            Horsepower = 45;
            LiftingCapacity = 1800;

        }
        public new void getSound()
        {
            Console.WriteLine("Pyrrrr pyrrrrr");
        }
    }
}
