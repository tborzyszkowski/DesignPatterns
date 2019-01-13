using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.BuilderExample
{
    public abstract class HouseBuilder
    {
        protected House house;

        public HouseBuilder()
        {
            house = new House();
        }

        public abstract HouseBuilder BuildFoundation();
        public abstract HouseBuilder BuildWalls();
        public abstract HouseBuilder BuildRoof();

        public static House GetHouse(HouseBuilder hb)
        {
            return hb.BuildFoundation()
                     .BuildWalls()
                     .BuildRoof()
                     .house;
        }
    }
}
