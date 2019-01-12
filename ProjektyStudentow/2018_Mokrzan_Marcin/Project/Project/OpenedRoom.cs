using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class OpenedRoom : State
    {


        public override void Handle(RoomInstance roomInstance)
        {
            roomInstance.State = new ClosedRoom();
        }

        public override string toString()
        {
            return "Opened";
        }
    }
}
