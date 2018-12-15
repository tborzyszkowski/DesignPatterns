using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.BuilderExample
{
    public class YellowHouseWithRedRoofBuilder : HouseBuilder
    {
        public override HouseBuilder BuildFoundation()
        {
            Console.WriteLine("Building foundation - yellow house with red roof");
            return this;
        }

        public override HouseBuilder BuildRoof()
        {
            house.roof = "red";
            return this;
        }

        public override HouseBuilder BuildWalls()
        {
            house.walls = "yellow";
            return this;
        }
    }
}
