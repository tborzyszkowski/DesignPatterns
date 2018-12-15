using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class NPCPrototype : ICloneable
    {
        string health;
        string money;
        string status;

        Ai ai = new Ai();

        public string Health { get => health; set => health = value; }
        public string Money { get => money; set => money = value; }
        public string Status { get => status; set => status = value; }
        public Ai Ai { get => ai; set => ai = value; }
        
        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        private object DeepCopy()
        {
            NPCPrototype npcClone = this.MemberwiseClone() as NPCPrototype;
            npcClone.Ai = new Ai();
            npcClone.Ai.Activity = this.Ai.Activity;
            npcClone.Ai.Behavior = this.Ai.Behavior;
            npcClone.Ai.Reaction = this.Ai.Reaction;

            return npcClone;
        }

        public object Clone()
        {
            return DeepCopy();
        }
    }
}
