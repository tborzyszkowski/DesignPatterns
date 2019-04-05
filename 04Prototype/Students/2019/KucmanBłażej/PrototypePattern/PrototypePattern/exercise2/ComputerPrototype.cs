using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.exercise2
{   
    [Serializable()]
    public abstract class ComputerPrototype
    {
        public ComputerPrototype CloneMemberwise()
        {
            return MemberwiseClone() as Computer;
        }
        public ComputerPrototype Duplicate()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            ComputerPrototype copy = (ComputerPrototype)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }
    }
}
