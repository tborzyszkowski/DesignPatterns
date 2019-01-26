using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ClosedRoom : State
    {
        public override void Handle(RoomInstance roomInstance)
        {
            roomInstance.State = new OpenedRoom();
        }

        public override string toString()
        {
            return "Closed";
        }
    }
}
