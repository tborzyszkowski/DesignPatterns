using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.BuilderExample
{
    public class GreenHouseWithBlueRoofBuilder : HouseBuilder
    {
        public override HouseBuilder BuildFoundation()
        {
            Console.WriteLine("Building foundation - green house with blue roof");
            return this;
        }

        public override HouseBuilder BuildRoof()
        {
            house.roof = "blue";
            return this;
        }

        public override HouseBuilder BuildWalls()
        {
            house.walls = "green";
            return this;
        }
    }
}
