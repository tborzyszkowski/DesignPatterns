using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FluentBuilder {
    class CarBuilder : VehicleBuilder {
        public CarBuilder() {
            vehicle = new Vehicle("Car");
        }

        public override VehicleBuilder BuildFrame() {
            vehicle["frame"] = "Car Frame";
            return this;
        }

        public override VehicleBuilder BuildEngine() {
            vehicle["engine"] = "2500 cc";
            return this;
        }

        public override VehicleBuilder BuildWheels() {
            vehicle["wheels"] = "4";
            return this;
        }

        public override VehicleBuilder BuildDoors() {
            vehicle["doors"] = "4";
            return this;
        }
    }
}
