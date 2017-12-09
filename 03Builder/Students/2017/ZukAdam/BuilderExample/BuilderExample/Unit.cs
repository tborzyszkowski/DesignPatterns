using System;

namespace BuilderExample
{
    public class Unit
    {
        public string Name { get; set; }

        public int Armor { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }

        public int Size { get; set; }

        public void PrintInfo()
        {
            var info = string.Empty;

            var props = this.GetType().GetProperties();

            foreach (var prop in props)
            {
                info += string.Format("{0} = {1}{2}", prop.Name, prop.GetValue(this), Environment.NewLine);
            }

            Console.WriteLine(info);
        }
    }
}
