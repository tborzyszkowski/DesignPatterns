using System;

namespace NestedDeepCopy
{
    [Serializable]
    public class SolarSystem
    {
        public Star Star;

        public SolarSystem(Star star)
        {
            Star = star;
        }
    }
}
