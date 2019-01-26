using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class RoomObserver : Observer
    {
        private string name;
        private State state;
        private RoomInstance subject;

        public RoomInstance Subject { get => subject; set => subject = value; }

        public RoomObserver(RoomInstance subject, string name)
        {
            this.subject = subject;
            this.name = name;
        }

        public override void Update()
        {
            state = subject.State;
            Console.WriteLine("Observer {0}'s new state is {1}",
              name, state.toString());
        }
    }
}
