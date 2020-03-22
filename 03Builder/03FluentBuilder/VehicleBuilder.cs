using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FluentBuilder {
	abstract class VehicleBuilder {
		protected Vehicle vehicle;

		Vehicle Vehicle => vehicle;

		public abstract VehicleBuilder BuildFrame();
		public abstract VehicleBuilder BuildEngine();
		public abstract VehicleBuilder BuildWheels();
		public abstract VehicleBuilder BuildDoors();

		public static implicit operator Vehicle(VehicleBuilder vb) =>
			vb
				.BuildFrame()
				.BuildEngine()
				.BuildWheels()
				.BuildDoors()
				.Vehicle;
	}
}
