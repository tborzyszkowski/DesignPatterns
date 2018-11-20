using System;
using System.Collections.Generic;

namespace PrototypePattern.Abstraction
{
    [Serializable]
    public abstract class BasePrototype<T> : IPrototype<T>
        where T : IPrototype<T>
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public ReferenceObject ReferenceObject { get; set; }
        public List<ReferenceObject> Collection { get; set; }

        public T ShallowClone()
        {
            return (T)this.MemberwiseClone();
        }

        public abstract T DeepClone();
    }

    [Serializable]
    public class ReferenceObject
    {
        public string Text { get; set; }
        public dynamic Dynamic { get; set; }
    }
}
