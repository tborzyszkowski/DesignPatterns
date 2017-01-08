using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Shoe shoe = new Shoe("Nike", "black","Air max", 10);
            shoe.Display();

            TShirt tshirt = new TShirt("Adidas", "green","Adi FX", 33);
            tshirt.Display();

            Console.WriteLine("\nSelling TShirt to Customers:");

            SellAble selltshirt = new SellAble(tshirt);
            selltshirt.SellItem("Customer #1");
            selltshirt.SellItem("Customer #2");

            selltshirt.Display();

            Console.ReadKey();
        }
    }
}
