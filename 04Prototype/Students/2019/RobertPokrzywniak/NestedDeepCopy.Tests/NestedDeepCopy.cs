using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NestedDeepCopy.Tests
{
    [TestClass]
    public class NestedDeepCopy
    {
        private static Cluster _cluster;
        private static Cluster _clusterDeepCopy;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _cluster = new Cluster("Virgo", new Galaxy(new SolarSystem(new Star("Sun", 333000))));
            _clusterDeepCopy = _cluster.DeepCopy();
        }
        [TestMethod]
        public void ObjectsShouldBeDifferent()
        {
            Assert.AreNotSame(_cluster, _clusterDeepCopy);
        }
        [TestMethod]
        public void NestedObjectsShouldBeDifferent()
        {
            Assert.AreNotSame(_cluster.Galaxy, _clusterDeepCopy.Galaxy);
            Assert.AreNotSame(_cluster.Galaxy.SolarSystem, _clusterDeepCopy.Galaxy.SolarSystem);
            Assert.AreNotSame(_cluster.Galaxy.SolarSystem.Star, _clusterDeepCopy.Galaxy.SolarSystem.Star);
        }
        [TestMethod]
        public void NestedValuesShouldBeEqual()
        {
            Assert.AreEqual(_cluster.Name, _clusterDeepCopy.Name);
            Assert.AreEqual(_cluster.Galaxy.SolarSystem.Star.Mass, _clusterDeepCopy.Galaxy.SolarSystem.Star.Mass);
            Assert.AreEqual(_cluster.Galaxy.SolarSystem.Star.Name, _clusterDeepCopy.Galaxy.SolarSystem.Star.Name);
        }
    }
}
