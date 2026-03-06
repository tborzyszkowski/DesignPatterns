using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02VehicleBuilder {
	class MainApp {
		static void Main(string[] args) {
			VehicleBuilder builder;

			var shop = new Shop();

			builder = new ScooterBuilder();
			shop.Construct(builder);
			builder.GetVehicle().Show();

			builder = new CarBuilder();
			shop.Construct(builder);
			builder.GetVehicle().Show();

			builder = new MotorCycleBuilder();
			shop.Construct(builder);
			builder.GetVehicle().Show();
		}
	}
}
