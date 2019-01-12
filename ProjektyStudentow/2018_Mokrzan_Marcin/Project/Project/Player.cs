using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Player : Component
    {
        string name;

        public string Name { get => name; set => name = value; }

        public override void AddChild(Component gr)
        {
            
        }

        public override string getName()
        {
            return this.name;
        }

        public override void Traverse()
        {
            
        }
    }
}
