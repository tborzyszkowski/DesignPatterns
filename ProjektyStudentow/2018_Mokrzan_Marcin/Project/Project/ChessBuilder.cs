using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ChessBuilder : RoomBuilder
    {
        public ChessBuilder()
        {
            room = new Room("Chess");
        }

        public override RoomBuilder SetRoomName()
        {
            room["name"] = "Chess Room";
            return this;
        }
        public override RoomBuilder SetRoomPassword()
        {
            room["pass"] = "987game123";
            return this;
        }
        public override RoomBuilder SetRoomNumberPlayer()
        {
            room["num"] = "2";
            return this;
        }
        public override RoomBuilder SetRoomTimeLimit()
        {
            room["time"] = "90";
            return this;
        }

    }
}
