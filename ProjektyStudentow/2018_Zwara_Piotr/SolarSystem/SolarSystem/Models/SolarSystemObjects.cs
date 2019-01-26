using System.Collections;
using System.Collections.Generic;

namespace SolarSystem.Models
{
    public class SolarSystemObjects : IEnumerable<IPlanet>
    {
        private readonly List<IPlanet> astronomicalObjects = new List<IPlanet>();

        public void Add(IPlanet aObject)
        {
            this.astronomicalObjects.Add(aObject);
        }

        public void AddRange(IEnumerable<IPlanet> aObjects)
        {
            this.astronomicalObjects.AddRange(aObjects);
        }

        public void Add(SolarSystemObjects solarSystemObjects)
        {
            this.astronomicalObjects.AddRange(solarSystemObjects);
        }

        public IEnumerator<IPlanet> GetEnumerator()
        {
            foreach (IPlanet aObject in this.astronomicalObjects)
                yield return aObject;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
