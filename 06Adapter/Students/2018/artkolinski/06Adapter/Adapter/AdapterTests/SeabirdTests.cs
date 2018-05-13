using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seabird;

namespace AdapterTests
{
    [TestClass]
    public class SeabirdTests
    {
        [TestMethod]
        public void EngineInSeabird()
        {
            IAircraft seabird = new Seabird.Seabird();
            seabird.TakeOff();
            Assert.AreEqual(100,seabird.Height);
            Assert.IsTrue(seabird.Airborne);
        }
        [TestMethod]
        public void IncreaseSeabirdSpeed()
        {
            IAircraft seabird = new Seabird.Seabird();
            ((ISeacraft) seabird).IncreaseRevs();
            ((ISeacraft) seabird).IncreaseRevs();
            Assert.AreEqual(0, seabird.Height);
            Assert.AreEqual(20, ((ISeacraft) seabird).Speed);
        }
        [TestMethod]
        public void IncreaseSeabirdToAircraftSpeed()
        {
            ISeacraft seabirdToAircraft = new SeabirdToAircraft();
            seabirdToAircraft.IncreaseRevs();
            seabirdToAircraft.IncreaseRevs();
            Assert.AreEqual(0, ((IAircraft)seabirdToAircraft).Height);
            Assert.AreEqual(20, seabirdToAircraft.Speed);
        }
        [TestMethod]
        public void EngineInSeabirdToAircraft()
        {
            ISeacraft seabirdToAircraft = new SeabirdToAircraft();
            ((IAircraft)seabirdToAircraft).TakeOff();
            Assert.AreEqual(100, ((IAircraft)seabirdToAircraft).Height);
            Assert.AreEqual(50, seabirdToAircraft.Speed);
            Assert.IsTrue(((IAircraft)seabirdToAircraft).Airborne);
        }
    }
}
