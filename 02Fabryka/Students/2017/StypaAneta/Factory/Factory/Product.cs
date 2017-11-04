using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Product
    {
        public string Name { get; set; }
        public string  Type { get; set; }

        public virtual void Print()
        {
           // throw new NotImplementedException();
        }
    }

    public class ProductA : Product
    {
        public override void Print() 
        {
            Console.WriteLine("Opis produktu A...");

        }
    }

    public class ProductB : Product
    {
        public override void Print()
        {
            Console.WriteLine("Opis produktu B...");
        }
    }
}
