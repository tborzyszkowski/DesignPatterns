using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using PrototypePattern.Abstraction;

namespace PrototypePattern.Implementation
{
    [Serializable]
    public class PrototypeUsingSerialization : BasePrototype<PrototypeUsingSerialization>
    {
        public override PrototypeUsingSerialization DeepClone()
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;

                return (PrototypeUsingSerialization)formatter.Deserialize(stream);
            }
        }
    }
}
