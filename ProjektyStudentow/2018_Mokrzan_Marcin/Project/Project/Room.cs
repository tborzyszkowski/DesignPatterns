using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Room : RoomInstance
    {
        private string gameName;
        private Dictionary<string, string> stats =
            new Dictionary<string, string>();

        public Room(string gameName)
        {
            this.GameName = gameName;
        }

        public string this[string key]
        {
            get { return Stats[key]; }
            set { Stats[key] = value; }
        }

        public string GameName { get => gameName; set => gameName = value; }
        public Dictionary<string, string> Stats { get => stats; set => stats = value; }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Game name: {0}", GameName);
            Console.WriteLine("Room name: {0}", Stats["name"]);
            Console.WriteLine("Number of player: {0}", Stats["num"]);
            Console.WriteLine("\n---------------------------");
        }
    }
}
