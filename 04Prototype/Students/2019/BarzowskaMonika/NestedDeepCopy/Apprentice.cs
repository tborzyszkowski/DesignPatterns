using System;

namespace NestedDeepCopy
{
    [Serializable]
    public class Apprentice
    {
        public Cat Cat;

        public Apprentice(Cat cat)
        {
            Cat = cat;
        }
    }
}
