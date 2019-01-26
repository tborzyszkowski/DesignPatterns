using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public abstract class NPCPrototype
    {
        string health;
        string money;
        string status;

        public string Health { get => health; set => health = value; }
        public string Money { get => money; set => money = value; }
        public string Status { get => status; set => status = value; }

        public abstract NPCPrototype Clone(); 
    }
}
