using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTeam
{
    public enum Color
    {
        White,
        Red,
        Green,
        Blue
    }

    public class Team
    {
        string Name { get; set; }
        string TrenerName { get; set; }
        Color ShirtColor { get; set; }
        string City { get; set; }
        string Type { get; set; }

        public Team(string name, string trenerName, Color shirtColor, string city, string type)
        {
            this.Name = name;
            this.TrenerName = trenerName;
            this.ShirtColor = shirtColor;
            this.City = city;
            this.Type = type;
        }

        public void Show()
        {
            Console.WriteLine("\n========================================\n");
            Console.WriteLine("Team name: " + Name);
            Console.WriteLine("Trener name: " + TrenerName);
            Console.WriteLine("Color shirt: " + ShirtColor);
            Console.WriteLine("City: " + City);
            Console.WriteLine("Team type: " + Type); 
        }
    }
}
