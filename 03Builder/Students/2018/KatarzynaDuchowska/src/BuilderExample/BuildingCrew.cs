using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.BuilderExample
{
    public class BuildingCrew
    {
        public House Construct(HouseBuilder builder)
        {
            return HouseBuilder.GetHouse(builder);
        }
    }
}
