using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype.DeepPrototype
{
    [Serializable]
    public abstract class Prototype<T> where T : class
    {
        public T ShallowClone()
        {
            return MemberwiseClone() as T;
        }

        public T DeepClone() //using serialization
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream) as T;
            }
        }

        public T DeepCloneByReflection() //using recursive reflection 
        {
            return ObjectExtensions.Copy(this) as T;
        }
    }
}
