using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComputerProjects.Models
{
    [Serializable]
    public class Computer : ComputerPrototype
    {
        public string Case { get; set; }
        public Motherboard Motherboard { get; set; }
        public override Computer DeepClone()
        {
            return DeepClone(this);
        }
        public override object ShallowClone()
        {
            return MemberwiseClone();
        }
        public T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
