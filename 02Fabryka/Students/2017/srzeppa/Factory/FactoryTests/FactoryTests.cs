using Factory;
using Factory.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTests
{
    [TestClass]
    public class FactoryTests
    {

        [TestMethod]
        public void CreateFactoryInstanceTest()
        {
            var factory1 = new VehicleFactory();
            var car = factory1.CreateVehicle("Car");
            car.Should().BeOfType<Car>();

            var factory2 = new VehicleFactory();
            var motorbike = factory2.CreateVehicle("Motorbike");
            motorbike.Should().BeOfType<Motorbike>();

            var factory3 = new VehicleFactory();
            var bike = factory3.CreateVehicle("Bike");
            bike.Should().BeOfType<Bike>();
        }
    }
}
