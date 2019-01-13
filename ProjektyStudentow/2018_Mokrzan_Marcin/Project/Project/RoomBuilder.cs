using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    abstract class RoomBuilder
    {
        protected Room room;

        Room Room
        {
            get { return room; }
        }

        public abstract RoomBuilder SetRoomName();
        public abstract RoomBuilder SetRoomPassword();
        public abstract RoomBuilder SetRoomNumberPlayer();
        public abstract RoomBuilder SetRoomTimeLimit();

        public static implicit operator Room(RoomBuilder rb)
        {
            return rb.SetRoomName()
                .SetRoomPassword()
                .SetRoomNumberPlayer()
                .SetRoomTimeLimit()
                .Room;
        }
    }
}
