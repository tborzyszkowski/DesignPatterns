using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComputerProjects.Models
{
    [Serializable]
    public class Computer2ForBuilder : ComputerBuilder
    {
        public Computer2ForBuilder()
        {
            Computer = new Computer();
        }
        public string Case { get; set; }
        public Motherboard Motherboard { get; set; }
        public Computer2ForBuilder DeepClone()
        {
            return DeepClone(this);
        }
        public object ShallowClone()
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

        public override void AddMotherboardWithProcessor()
        {
            var processor = new Processor { Model = "Intel i7" };
            var motherboard = new Motherboard { Name = "Build 2 Motherboard", Processor = processor };
            Computer.Motherboard = motherboard;
        }

        public override void AddCase()
        {
            Computer.Case = "Build2 Case";
        }

        public override Computer GetComputer()
        {
            return Computer;
        }
    }
}
