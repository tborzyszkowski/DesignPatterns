using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Cars
{
    public class SmallCarChina : Car
    {
        public SmallCarChina()
        {
            Name = "Mini";
            Price = 75000;
            Speed = 203;
            Horsepower = 163;
            CapacityPeople = 4;

        }
        public new void getSound()
        {
            Console.WriteLine("Brum brum");
        }


    }
}
