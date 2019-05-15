using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NestedDeepCopy
{
    [Serializable]
    public abstract class Prototype<T> where T : class
    {
        public T DeepCopy()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream) as T;
            }
        }
    }
}
