using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02VehicleBuilder {
    class CarBuilder : VehicleBuilder {
        public CarBuilder() {
            vehicle = new Vehicle("Car");
        }

        public override void BuildFrame() {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildEngine() {
            vehicle["engine"] = "2500 cc";
        }

        public override void BuildWheels() {
            vehicle["wheels"] = "4";
        }

        public override void BuildDoors() {
            vehicle["doors"] = "4";
        }
    }
}
