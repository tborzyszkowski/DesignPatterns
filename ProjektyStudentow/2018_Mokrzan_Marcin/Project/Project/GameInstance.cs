using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class GameInstance : Component
    {
        private ArrayList ComponentList = new ArrayList();
        public override void AddChild(Component gr)
        {
            ComponentList.Add(gr);
        }

        public override void Traverse()
        {
            
        }

        public void Show()
        {
            Console.WriteLine("-root");
            foreach (Component comp in ComponentList)
            {
                Console.WriteLine("---" + comp.getName());
            }
        }

        public override string getName()
        {
            return "Game";
        }
    }
}
