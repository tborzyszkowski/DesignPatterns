using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Trucks
{
    public abstract class Truck : IWehicle
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Speed { get; set; }
        public int Horsepower { get; set; }

        public int FuelTank { get; set; }
        public void getSound()
        {
            Console.WriteLine("Whrum");
        }
    }
}
