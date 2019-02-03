using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Sheep : Character
    {
        public int health { get; set; }

        public Character copy()
        {
            Sheep newSheep = new Sheep();
            newSheep.health = health/2;
            return newSheep;
        }

        public Sheep()
        {
            health = 100;
        }
    }
}
