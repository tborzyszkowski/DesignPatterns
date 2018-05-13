using System;
using ComputerProjects.Models;

namespace ComputerProjects
{
    [Serializable]
    public abstract class ComputerPrototype
    {
        public abstract Computer DeepClone();
        public abstract object ShallowClone();
    }
}
