using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Client
    {
        static void Main(string[] args)
        {
            Adapter adapter1 = new Adapter(new Adaptee());
            Console.WriteLine(adapter1.Request("Dualshock4"));
           
            Adapter adapter2 = new Adapter(new Target());
            Console.WriteLine(adapter2.Request("2"));

            Adapter adapter3 = new Adapter(new Adaptee());
            Console.WriteLine(adapter3.Request("XboxOneController"));

            Adapter adapter4 = new Adapter(new Target());
            Console.WriteLine(adapter4.Request("4"));

            Console.ReadKey();
        }
    }
}
