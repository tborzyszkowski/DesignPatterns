using Builder.BuilderExample;
using NUnit.Framework;
using System;
using Builder;


namespace Tests
{
    [TestFixture]
    public class BuilderExample
    {
        [Test]
        public void YellowHouseWithRedRoof()
        {
            HouseBuilder builder = new YellowHouseWithRedRoofBuilder();
            BuildingCrew crew = new BuildingCrew();

            House house = crew.Construct(builder);

            Assert.True(house.walls == "yellow" && house.roof == "red");
        }

        [Test]
        public void GreenHouseWithBlueRoof()
        {
            HouseBuilder builder = new GreenHouseWithBlueRoofBuilder();
            BuildingCrew crew = new BuildingCrew();

            House house = crew.Construct(builder);

            Assert.True(house.walls == "green" && house.roof == "blue");
        }
    }
}
