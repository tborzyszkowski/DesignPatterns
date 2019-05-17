using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    [Serializable()]

    public abstract class KingPrototype
    {
        public KingPrototype CloneMemberwise()
        {
            return MemberwiseClone() as King;
        }
        // głebokie klonowanie za pomocą serializacji
        public KingPrototype Usurper()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;

            return formatter.Deserialize(stream) as KingPrototype;
        }
    }

    
}
