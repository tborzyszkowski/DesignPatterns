using System;

namespace NestedDeepCopy
{
    [Serializable]
    public class Cluster : Prototype<Cluster>
    {
        public string Name;
        public Galaxy Galaxy;

        public Cluster(string name, Galaxy galaxy)
        {
            Name = name;
            Galaxy = galaxy;
        }
    }
}
