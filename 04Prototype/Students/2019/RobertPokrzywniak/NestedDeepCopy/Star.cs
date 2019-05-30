using System;

namespace NestedDeepCopy
{
    [Serializable]
    public class Star
    {
        public string Name;
        public long Mass;

        public Star(string name, long mass)
        {
            Name = name;
            Mass = mass;
        }
    }
}
