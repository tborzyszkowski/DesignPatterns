using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NestedShallowCopy.Tests
{
    [TestClass]
    public class NestedShallowCopy
    {
        private static Cluster _cluster;
        private static Cluster _clusterShallowCopy;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _cluster = new Cluster("Virgo", new Galaxy(new SolarSystem(new Star("Sun",333000))));
            _clusterShallowCopy = _cluster.ShallowCopy();
        }
        [TestMethod]
        public void ObjectsShouldBeDifferent()
        {
            Assert.AreNotSame(_cluster,_clusterShallowCopy);
        }
        [TestMethod]
        public void NestedObjectsShouldBeSame()
        {
            Assert.AreSame(_cluster.Galaxy, _clusterShallowCopy.Galaxy);
            Assert.AreSame(_cluster.Galaxy.SolarSystem, _clusterShallowCopy.Galaxy.SolarSystem);
            Assert.AreSame(_cluster.Galaxy.SolarSystem.Star, _clusterShallowCopy.Galaxy.SolarSystem.Star);
        }
        [TestMethod]
        public void NestedValuesShouldBeEqual()
        {
            Assert.AreEqual(_cluster.Name, _clusterShallowCopy.Name);
            Assert.AreEqual(_cluster.Galaxy.SolarSystem.Star.Mass, _clusterShallowCopy.Galaxy.SolarSystem.Star.Mass);
            Assert.AreEqual(_cluster.Galaxy.SolarSystem.Star.Name, _clusterShallowCopy.Galaxy.SolarSystem.Star.Name);
        }
    }
}
