using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class TerrainComponent : ITerrainComponent //Composite
    {
        int index;
        public TerrainComponent(int number)
        {
            index = number;
        }
        public void PutInMap()
        {
            Console.WriteLine("SUCCESS: Component put in map");
        }
    }
}
