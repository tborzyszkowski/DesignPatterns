using Factory.AbstractFactory;
using Factory.MilitaryVehicles;
using Factory.MilitaryVehicles.Tanks;
using Factory.MilitaryVehicles.Warplanes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTest
{
    [TestClass]
    public class AbstractFactoryTest
    {
        [TestMethod]
        public void UseOfDefaultAbstractFactoryToCreateWarplane()
        {
            Base ukBase = new UKBase(); //Default IFactorySet == UKFactorySet
            IMilitaryVehicle warplane = ukBase.BuildWarplane();
            Assert.IsNotNull(warplane as Spitfire);
        }

        [TestMethod]
        public void UseOfSpecificAbstractFactoryToCreateWarplane()
        {
            Base ukBase = new UKBase(GermanFactorySet.Instance);
            IMilitaryVehicle tank = ukBase.BuildTank();
            Assert.IsNotNull(tank as Tiger);
        }
    }
}
