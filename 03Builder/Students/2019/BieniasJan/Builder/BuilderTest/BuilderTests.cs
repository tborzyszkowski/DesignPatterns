using Builder.FactoryOverBuilder.FluentBuilder;
using Builder.FactoryOverBuilder.SimpleBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuilderTest
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void ConcreteFluentBuilderSetsUpParamsCorrectly()
        {
            var tankFactory = new TankFactory();
            var tank = tankFactory.Construct(new TigerTankBuilder());
            Assert.AreEqual("Tiger I", tank.Name);
        }

        [TestMethod]
        public void ConcreteSimpleBuilderSetsUpParamsCorrectly()
        {
            var airfield = new Airfield();
            var builder = new SpitfireWarplaneBuilder();
            airfield.Construct(builder);
            var warplane = builder.Warplane;
            Assert.AreEqual("Supermarine Spitfire", warplane.Name);
        }
    }
}
