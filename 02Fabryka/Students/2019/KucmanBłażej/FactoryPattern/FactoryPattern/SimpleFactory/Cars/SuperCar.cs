using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Cars
{
    class SuperCar : Car
    {
        public SuperCar()
        {
            Name = "Mini";
            Price = 19500000;
            Speed = 380;
            Horsepower = 1500;
            CapacityPeople = 2;

        }
        public new void getSound()
        {
            Console.WriteLine("WRrrruummmmm Wruuuuuuuummmm wziuuuuuuuu");
        }
    }
}
