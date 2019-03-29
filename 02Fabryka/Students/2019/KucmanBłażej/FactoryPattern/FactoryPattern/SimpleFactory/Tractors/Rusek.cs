using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Tractors
{
    class Rusek : Tractor
    {
        public Rusek()
        {
            Name = "T25";
            Price = 10000;
            Speed = 25;
            Horsepower = 31;
            LiftingCapacity = 600;

        }
        public new void getSound()
        {
            Console.WriteLine("Pyr pyr");
        }

    }   
}
