using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Starbuzz {
    class MainApp {
        static void Main(string[] args) {
            //Expresso
            Beverage expresso = new Espresso();
            Console.WriteLine(expresso.Description + " $" + expresso.Cost());
            
            Beverage houseBlend = new HouseBlend();
            houseBlend = new Mocha(houseBlend);
            houseBlend = new Soy(houseBlend);
            Console.WriteLine(houseBlend.Description + " $" + houseBlend.Cost());
            
            Beverage darkRoast = new DarkRoast();
            darkRoast = new CoffeeMate(darkRoast);
            Console.WriteLine(darkRoast.Description + " $" + darkRoast.Cost());

            Console.ReadKey();
        }
    }
}
