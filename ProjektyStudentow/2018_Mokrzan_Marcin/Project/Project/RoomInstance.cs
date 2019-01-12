using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class RoomInstance : Component
    {
        //string subjectState;
        string name;
        State state;

        public string Name { get => name; set => name = value; }
        public State State { get => state; set => state = value; }
        public ArrayList ComponentList1 { get => ComponentList; set => ComponentList = value; }
        

        ArrayList ComponentList = new ArrayList();
        
        public RoomInstance()
        {
            this.state = new OpenedRoom();
        }

        public override void AddChild(Component gr)
        {
            ComponentList1.Add(gr);
        }

        public override string getName()
        {
            return this.name;
        }

        public override void Traverse()
        {
            
        }

        public void Show()
        {
            foreach (Component comp in ComponentList1)
            {
                Console.WriteLine("-----" + comp.getName());
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}
