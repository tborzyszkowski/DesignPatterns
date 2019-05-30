using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Products
{
    public abstract class Rice : Carbohydrate
    {
        public Packaging Packaging { get; set; }
        public void Open()
        {
            Console.WriteLine("Opening: " + Type);
        }
        public override void Boil()
        {
            Console.WriteLine("Boiling rice: " + this);
        }
        public override void Eat()
        {
            Console.WriteLine("Eating rice: " + Type);
        }
    }
}
