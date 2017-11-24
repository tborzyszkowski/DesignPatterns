using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryAbstract.Fabryka;

namespace FactoryAbstract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZooFactory catFactory = new ZooFactoryB();
            ZooFactory hedgeHogFactory = new ZooFactoryA();

            var cat = catFactory.FactoryMethod();
            var hedgehog = hedgeHogFactory.FactoryMethod();

            Console.WriteLine(cat.ToString());
            Console.WriteLine(hedgehog.ToString());

        }
    }
}
