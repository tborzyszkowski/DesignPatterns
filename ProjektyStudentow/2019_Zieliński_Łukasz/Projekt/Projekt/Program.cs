using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Factory;
using Projekt.Factory.Products;
using Projekt.Observer;
using Projekt.Prototype;
using Projekt;
using Projekt.Adapter;

namespace Projekt
{
    // Sklep z drewnianymi meblami
    class Program
    {
        static void Main(string[] args)
        {
            Notification info = new Notification();
            AFactory aFactory = new Factory1(LocalFactory.Instance);
            Console.WriteLine();
            Order.Ordered();
           

            Console.ReadKey();
        }
    }
}
