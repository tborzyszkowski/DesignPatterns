using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FluentBuilder {
    class ScooterBuilder : VehicleBuilder {
        public ScooterBuilder() {
            vehicle = new Vehicle("Scooter");
        }

        public override VehicleBuilder BuildFrame() {
            vehicle["frame"] = "Scooter Frame";
            return this;
        }

        public override VehicleBuilder BuildEngine() {
            vehicle["engine"] = "50 cc";
            return this;
        }

        public override VehicleBuilder BuildWheels() {
            vehicle["wheels"] = "2";
            return this;
        }

        public override VehicleBuilder BuildDoors() {
            vehicle["doors"] = "0";
            return this;
        }
    }
}
