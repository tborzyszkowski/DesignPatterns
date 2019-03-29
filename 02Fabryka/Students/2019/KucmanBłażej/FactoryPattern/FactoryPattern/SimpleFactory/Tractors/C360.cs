using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory.Tractors
{
    class C360 : Tractor
    {
        public C360()
        {
            Name = "Sześćdziesiatka";
            Price = 16500;
            Speed = 25;
            Horsepower = 52;
            LiftingCapacity = 1200;

        }
        public new void getSound()
        {
            Console.WriteLine("Pyrr pyrr pyr");
        }
    }
}
