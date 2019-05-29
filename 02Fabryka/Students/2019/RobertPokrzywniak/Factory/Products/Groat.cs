using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products
{
    public abstract class Groat : Carbohydrate
    {
        public float Weight { get; set; }
        public void Mix()
        {
            Console.WriteLine("Mixing groat: " + Type);
        }
        public override void Boil()
        {
            Console.WriteLine("Boiling groat: " + this);
        }
        public override void Eat()
        {
            Console.WriteLine("Eating groat: " + Type);
        }
        public override string ToString()
        {
            return (Brand + " | " + Type + " | ") +
            "$" + Price + " | " + BoilTime + "min | " + Weight +
            "kg";
        }
    }
}
