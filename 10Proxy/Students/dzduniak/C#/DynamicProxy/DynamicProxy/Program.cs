using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Target();
            dynamic dp = new DynamicProxy(t);

            Console.WriteLine(dp.Method1());
            Console.WriteLine(dp.Method2());
            Console.WriteLine(dp.Method3());
            Console.ReadKey();
        }
    }
}
