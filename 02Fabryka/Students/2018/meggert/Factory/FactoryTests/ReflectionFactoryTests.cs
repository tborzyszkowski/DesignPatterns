using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionFactory.Model;
using ReflectionFactory;
using FluentAssertions;

namespace FactoryTests
{
    [TestClass]
    public class ReflectionFactoryTests
    {

        [TestMethod]
        public void CreateInstanceReflectionTest()
        {
            var vehicle1 = VehicleFactory.CreateVehicle<Car>();
            var vehicle2 = VehicleFactory.CreateVehicle("Motorbike");

            vehicle1.Should().BeOfType<Car>();
            vehicle1.Name.Should().Be("Car");
            vehicle1.Wheels.Should().Be(4);
            vehicle1.HasEngine.Should().BeTrue();

            vehicle2.Should().BeOfType<Motorbike>();
            vehicle2.Name.Should().Be("Motorbike");
            vehicle2.Wheels.Should().Be(2);
            vehicle2.HasEngine.Should().BeTrue();
        }

    }
}
