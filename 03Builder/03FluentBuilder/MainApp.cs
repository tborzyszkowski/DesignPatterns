using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FluentBuilder {
    // 
    // See more on FluentInterface:
    // http://www.martinfowler.com/bliki/FluentInterface.html
    class MainApp {
        static void Main(string[] args) {

            // Create shop with vehicle builders
            Shop shop = new Shop();

            // Construct and display vehicles
            Vehicle scooter = shop.Construct(new ScooterBuilder());
            scooter.Show();

            shop.Construct(new CarBuilder()).Show();

            // Wait for user
            Console.ReadKey();
        }
    }
}
