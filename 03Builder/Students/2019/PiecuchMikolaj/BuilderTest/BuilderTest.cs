using System;
using Builder.Builders;
using Builder.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderTest
{
    [TestClass]
    public class BuilderTest
    {
        [TestMethod]
        public void ShouldBuildSpeedVehicle()
        {
            Vehicle vehicle = new VehicleDirector()
                .NewVehicle
                .SetMaxSpeed(90)
                .SetType(VehicleType.Delivery)
                .SetWheels(4);

            Assert.AreEqual(vehicle.MaxSpeed, 90);
            Assert.AreEqual(vehicle.Type, VehicleType.Delivery);
            Assert.AreEqual(vehicle.Wheels, 4);
        }
    }
}
