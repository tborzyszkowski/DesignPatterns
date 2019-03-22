using Factory.MilitaryVehicles;
using Factory.MilitaryVehicles.Tanks;
using Factory.SimpleFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTest
{
    [TestClass]
    public class SimpleFactoryTest
    {
        [TestMethod]
        public void CreateSpecificTankThatExists()
        {
            var vehicleFactory = new VehicleFactory();
            IMilitaryVehicle tank = vehicleFactory.BuildTank("churchill");
            Assert.IsNotNull(tank as Churchill);
        }

        [TestMethod]
        public void CreateSpecificTankThatDoesNotExist()
        {
            var vehicleFactory = new VehicleFactory();
            IMilitaryVehicle tank = vehicleFactory.BuildTank(string.Empty);
            Assert.IsNull(tank);
        }
    }
}
