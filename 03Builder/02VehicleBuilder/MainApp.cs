using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02VehicleBuilder {
    class MainApp {
        static void Main(string[] args) {
            VehicleBuilder builder;

            // Create shop with vehicle builders
            Shop shop = new Shop();

            // Construct and display vehicles
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.GetVehicle().Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.GetVehicle().Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.GetVehicle().Show();

            // Wait for user
            Console.ReadKey();
        }
    }
}
