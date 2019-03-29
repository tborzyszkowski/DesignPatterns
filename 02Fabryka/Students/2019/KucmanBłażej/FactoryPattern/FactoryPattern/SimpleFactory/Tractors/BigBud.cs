using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Tractors
{
    class BigBud : Tractor
    {
        public BigBud()
        {
            Name = "Beast";
            Price = 1200000;
            Speed = 13;
            Horsepower = 1100;
            LiftingCapacity = 55000;

        }
        public new void getSound()
        {
            Console.WriteLine("Whrrrrrum Whruuuuuuum");
        }
    }
}
