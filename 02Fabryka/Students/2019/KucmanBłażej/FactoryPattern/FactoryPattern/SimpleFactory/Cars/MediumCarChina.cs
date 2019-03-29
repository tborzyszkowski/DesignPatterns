using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Cars
{
    public class MediumCarChina : Car
    {
        public MediumCarChina()
        {
            Name = "Passacik";
            Price = 70000;
            Speed = 185;
            Horsepower = 102;
            CapacityPeople = 5;

        }
        public new void getSound()
        {
            Console.WriteLine("Bhrumm Bhrum");
        }
    }
}
