using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Cars
{
    public class HighClasCarChina : Car
    {
        public HighClasCarChina()
        {
            Name = "CLS";
            Price = 230000;
            Speed = 250;
            Horsepower = 367;
            CapacityPeople = 5;

        }
        public new void getSound()
        {
            Console.WriteLine("Bruuuuuuuuum Brummmmmmmm !!!!!!");
        }
    }
}
