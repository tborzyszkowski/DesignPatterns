using Factory.FactoryMethod;
using Factory.MilitaryVehicles;
using Factory.MilitaryVehicles.Warships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTest
{
    [TestClass]
    public class FactoryMethodTest
    {
        [TestMethod]
        public void CreateSpecificWarshipFromSpecificShipyardThatExists()
        {
            IMilitaryVehicle warship = Shipyard.Instance.Build("valkyrie");
            Assert.IsNotNull(warship as Valkyrie);
        }

        [TestMethod]
        public void CreateSpecificWarshipFromSpecificShipyardThatDoesNotExist()
        {
            IMilitaryVehicle warship = Shipyard.Instance.Build(string.Empty);
            Assert.IsNull(warship);
        }
    }
}
