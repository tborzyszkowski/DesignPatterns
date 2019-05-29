using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products
{
    public abstract class Pasta : Carbohydrate
    {
        public void Break()
        {
            Console.WriteLine("Breaking pasta: " + Type);
        }
        public override void Boil()
        {
            Console.WriteLine("Boiling pasta: " + this);
        }
        public override void Eat()
        {
            Console.WriteLine("Eating pasta: " + Type);
        }
    }
}
