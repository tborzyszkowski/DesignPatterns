using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class TerrainComposite : ITerrainComponent //Composite
    {
        List<ITerrainComponent> components = new List<ITerrainComponent>();
        public void PutInMap()
        {
            foreach (ITerrainComponent component in components)
            {
                component.PutInMap();
            }
        }

        public void Add(ITerrainComponent tc)
        {
            components.Add(tc);
        }

        public void Remove(ITerrainComponent tc)
        {
            components.Remove(tc);
        }
    }
}
