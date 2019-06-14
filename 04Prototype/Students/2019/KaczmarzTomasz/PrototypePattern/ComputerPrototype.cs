using PrototypePattern.Deep;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypePattern
{
    [Serializable]
    abstract class ComputerPrototype
    {
        public abstract ComputerPrototype Clone();
        public abstract ComputerPrototype DeepCopy();
    }

    [Serializable]
    class Computer : ComputerPrototype
    {
        private string cpu;
        private string gpu;
        private string ram;
        public Casing casing;

        public Computer(string cpu, string gpu, string ram)
        {
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.casing = new Casing(new PowerSupply(0, new Fan(0)));
        }

        public Computer(string cpu, string gpu, string ram, Casing casing)
        {
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.casing = casing;
        }

        public override ComputerPrototype Clone()
        {
            Console.WriteLine("Cloning computer: {0}, {1}, {2}, {3}W, {4}mm", cpu, gpu, ram, casing.powerSupply.power, casing.powerSupply.fan.diameter);
            return this.MemberwiseClone() as ComputerPrototype;
        }

        public override ComputerPrototype DeepCopy()
        {
            ComputerPrototype copy;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                copy = (ComputerPrototype)formatter.Deserialize(stream);
            }
            Console.WriteLine("Deep copying: {0}, {1}, {2}, {3}W, {4}mm", cpu, gpu, ram, casing.powerSupply.power, casing.powerSupply.fan.diameter);
            return copy;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}W, {4}mm", cpu, gpu, ram, casing.powerSupply.power, casing.powerSupply.fan.diameter);
        }
    }
}
