using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Pizza
    {
        public string Name { get; set; }
        public string  Type { get; set; }

        public virtual void Print()
        {

        }
    }

    public class Pizza1 : Pizza
    {
        public override void Print() 
        {
            Console.WriteLine("Opis pizzy nr 1");

        }
    }

    public class Pizza2 : Pizza
    {
        public override void Print()
        {
            Console.WriteLine("Opis pizzy nr 2");
        }
    }
}
