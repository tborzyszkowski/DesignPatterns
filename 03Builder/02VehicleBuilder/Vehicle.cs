using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02VehicleBuilder {
	class Vehicle {
		private string _vehicleType;
		private Dictionary<string, string> _parts =
		  new Dictionary<string, string>();

		public Vehicle(string vehicleType) =>
			this._vehicleType = vehicleType;

		public string this[string key] {
			get => _parts[key];
			set => _parts[key] = value;
		}

		public void Show() {
			Console.WriteLine("\n---------------------------");
			Console.WriteLine($"Vehicle Type: {_vehicleType}");
			Console.WriteLine($" Frame : {_parts["frame"]}");
			Console.WriteLine($" Engine : {_parts["engine"]}");
			Console.WriteLine($" #Wheels: {_parts["wheels"]}");
			Console.WriteLine($" #Doors : {_parts["doors"]}");
		}
	}
}
