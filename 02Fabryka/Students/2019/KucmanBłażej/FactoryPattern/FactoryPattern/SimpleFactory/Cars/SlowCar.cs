using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Cars
{
    public class SlowCar : Car
    {
        public SlowCar()
        {
            Name = "Uno";
            Price = 20000;
            Speed = 140;
            Horsepower = 45;
            CapacityPeople = 5;

        }
        public new void getSound()
        {
            Console.WriteLine("pyrrrr...  Brum");
        }
    }
}
