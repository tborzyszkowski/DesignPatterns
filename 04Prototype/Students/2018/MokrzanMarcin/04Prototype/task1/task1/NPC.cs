using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class NPC : NPCPrototype
    {
        public override NPCPrototype Clone()
        {
            return this.MemberwiseClone() as NPC;
        }
    }
}
