using System;

namespace NestedDeepCopy
{
    [Serializable]
    public class Cat
    {
        public Toy Toy;

        public Cat(Toy toy)
        {
            Toy = toy;
        }
    }
}
