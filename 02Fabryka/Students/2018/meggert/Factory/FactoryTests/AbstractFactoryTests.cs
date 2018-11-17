using AbstractFactory;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTests
{
    [TestClass]
    public class AbstractFactoryTests
    {

        [TestMethod]
        public void CreateInstanceTest()
        {
            var vehicle1 = new CarFactory();
            var vehicle2 = new MotorbikeFactory();
            var vehicle3 = new BikeFactory();

            vehicle1.Should().BeOfType<CarFactory>();
            vehicle2.Should().BeOfType<MotorbikeFactory>();
            vehicle3.Should().BeOfType<BikeFactory>();

            var car = vehicle1.Factory();
            car.Name.Should().Be("Car");
            car.Wheels.Should().Be(4);
            car.HasEngine.Should().BeTrue();

            var motorBike = vehicle2.Factory();
            motorBike.Name.Should().Be("Motorbike");
            motorBike.Wheels.Should().Be(2);
            motorBike.HasEngine.Should().BeTrue();

            var bike = vehicle3.Factory();
            bike.Name.Should().Be("Bike");
            bike.Wheels.Should().Be(2);
            bike.HasEngine.Should().BeFalse();
        }

    }
}
