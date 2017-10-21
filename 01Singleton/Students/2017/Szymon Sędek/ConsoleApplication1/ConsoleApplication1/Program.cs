using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var testing = new Testing();
            testing.Draw();
            testing.STH();
            var testing2=new Testing();
            testing2.STH();
            testing2.Draw();


            Console.ReadKey();
        }
    }
}
