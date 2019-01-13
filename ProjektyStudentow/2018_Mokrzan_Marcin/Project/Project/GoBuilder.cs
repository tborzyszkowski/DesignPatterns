using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class GoBuilder : RoomBuilder
    {
        public GoBuilder()
        {
            room = new Room("Go");
        }

        public override RoomBuilder SetRoomName()
        {
            room["name"] = "Go Room";
            return this;
        }
        public override RoomBuilder SetRoomPassword()
        {
            room["pass"] = "123pas345";
            return this;
        }
        public override RoomBuilder SetRoomNumberPlayer()
        {
            room["num"] = "2";
            return this;
        }
        public override RoomBuilder SetRoomTimeLimit()
        {
            room["time"] = "30";
            return this;
        }

    }
}
