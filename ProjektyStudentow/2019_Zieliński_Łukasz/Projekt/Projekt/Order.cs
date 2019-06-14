using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Factory.Products;
using Projekt.Factory;
using Projekt.Adapter;

namespace Projekt
{

    public class Order : Product
    {
        
        
        
        public static void Ordered()
        {
            List<Product> Items = new List<Product>();
            int cena=0;
            Product rzecz;
            Product klon;

            AFactory aFactory = new Factory1(LocalFactory.Instance);
            Console.WriteLine("Zamówiono: Mały Stół i 4 krzesła");
            int x = 4;
            rzecz = aFactory.CreateSTable() as Product;
            Console.WriteLine(rzecz);
            Items.Add(rzecz);
            cena += rzecz.cost;
            AdapterItem adapt = new AdapterItem(rzecz);

            rzecz = aFactory.CreateChair() as Product;
            cena += rzecz.cost;
            Console.WriteLine(rzecz);
            Items.Add(rzecz);
            for(int i = 0; i < x - 1; i++)
            {
                klon = rzecz.Clone() as Product;
                Items.Add(klon);
                Console.WriteLine(klon);
                cena += klon.cost;
            }

            Console.WriteLine("\nCałe zamówienie: \n");
            foreach (Product a in Items)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Kwota do zapłaty: "+cena);
        }
    }
}
