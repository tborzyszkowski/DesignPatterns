using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Character
    {
        private string professionName;
        private Dictionary<string, string> stats =
            new Dictionary<string, string>();

        public Character(string professionName){
            this.professionName = professionName;
        }

        public string this[string key]
        {
            get { return stats[key]; }
            set { stats[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Profession Name: {0}", professionName);
            Console.WriteLine(" Strength : {0}", stats["str"]);
            Console.WriteLine(" Intelligence : {0}", stats["int"]);
            Console.WriteLine(" Agility: {0}", stats["agi"]);
            Console.WriteLine(" Dexterity: {0}", stats["dex"]);
        }

    }
}
