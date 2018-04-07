using System;
using DeepPrototype.Models;

namespace DeepPrototype
{
    [Serializable]
    public abstract class ComputerPrototype
    {
        public abstract Computer DeepClone();
        public abstract object ShallowClone();
    }
}
