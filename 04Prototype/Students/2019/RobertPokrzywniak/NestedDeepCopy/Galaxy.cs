using System;

namespace NestedDeepCopy
{
    [Serializable]
    public class Galaxy
    {
        public SolarSystem SolarSystem;

        public Galaxy(SolarSystem solarSystem)
        {
            SolarSystem = solarSystem;
        }
    }
}
