using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.Cars
{
    class Yaris : Car
    {
        public Yaris()
        {
            Name = "Toyota Yaris";
            MaxSpeed = 120;
            HP = 10;
        }

        public string BreakCar() => "500 m";
    }
}
