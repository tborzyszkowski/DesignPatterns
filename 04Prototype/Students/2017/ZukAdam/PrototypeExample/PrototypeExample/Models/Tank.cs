using BinaryFormatter;
using System;

namespace PrototypeExample.Models
{
    public class Tank  // No ICloneable interface in .NET core
    {
        public string Name { get; set; }

        public int Speed { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Length { get; set; }

        public Turret Turret { get; set; }

        public Tank ShallowClone()
        {
            return (Tank)this.MemberwiseClone();
        }

        public Tank DeepClone()
        {
            var converter = new BinaryConverter();
            byte[] byteArray = converter.Serialize(this);

            var copy = converter.Deserialize<Tank>(byteArray);

            return copy;
        }

        public void PrintInfo()
        {
            var info = string.Format("Name: {0}\nSpeed: {1}\nWidth: {2}\nHeight: {3}\nTurret: {4}",
                                     this.Name, this.Speed, this.Width, this.Height, this.Turret);
            Console.WriteLine(info);
        }
    }
}
