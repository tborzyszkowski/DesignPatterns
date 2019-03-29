using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Cars
{
    public class SmallCar : Car
    {
        public SmallCar()
        {
            Name = "Mini";
            Price = 82000;
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
