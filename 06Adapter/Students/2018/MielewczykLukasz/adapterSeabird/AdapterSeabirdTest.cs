using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterSeabird
{
    [TestClass]
    public class SeabirdTests
    {

        [TestMethod]
        public void TestAircraft()
        {
            IAircraft aircraft = new Aircraft();
            Assert.IsFalse(aircraft.Airborne);
            Assert.AreEqual(0, aircraft.Height);
            aircraft.TakeOff();
            Assert.IsTrue(aircraft.Airborne);
            Assert.AreEqual(200, aircraft.Height);
        }

        [TestMethod]
        public void TestSeacraft()
        {
            ISeacraft seabird = new Seacraft();
            Assert.AreEqual(0, seabird.Speed);
            seabird.IncreaseRevs();
            Assert.AreEqual(10, seabird.Speed);
            seabird.IncreaseRevs();
            Assert.AreEqual(20, seabird.Speed);
        }

        [TestMethod]
        public void TestIncreaseRevsSpeedLessThan40()
        {
            ISeacraft seabird = new Seabird();
            seabird.IncreaseRevs();
            seabird.IncreaseRevs();
            Assert.IsFalse(((IAircraft)seabird).Airborne);
            Assert.AreEqual(0, ((IAircraft)seabird).Height);
            Assert.AreEqual(20, seabird.Speed);
        }

        [TestMethod]
        public void TestIncreaseRevsSpeedGreaterThan40()
        {
            ISeacraft seabird = new Seabird();
            seabird.IncreaseRevs();
            seabird.IncreaseRevs();
            seabird.IncreaseRevs();
            seabird.IncreaseRevs();
            seabird.IncreaseRevs();
            Assert.IsTrue(((IAircraft)seabird).Airborne);
            Assert.AreEqual(100, ((IAircraft)seabird).Height);
            Assert.AreEqual(50, seabird.Speed);
        }

        [TestMethod]
        public void TestTakeOff()
        {
            ISeacraft seabird = new Seabird();
            ((IAircraft)seabird).TakeOff();
            Assert.IsTrue(((IAircraft)seabird).Airborne);
            Assert.AreEqual(100, ((IAircraft)seabird).Height);
            Assert.AreEqual(50, seabird.Speed);
        }

    }
}

