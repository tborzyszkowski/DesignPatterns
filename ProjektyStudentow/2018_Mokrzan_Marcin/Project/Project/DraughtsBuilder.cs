using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class DraughtsBuilder : RoomBuilder
    {
        public DraughtsBuilder()
        {
            room = new Room("Draughts");
        }

        public override RoomBuilder SetRoomName()
        {
            room["name"] = "Draughts Room";
            return this;
        }
        public override RoomBuilder SetRoomPassword()
        {
            room["pass"] = "456game123";
            return this;
        }
        public override RoomBuilder SetRoomNumberPlayer()
        {
            room["num"] = "2";
            return this;
        }
        public override RoomBuilder SetRoomTimeLimit()
        {
            room["time"] = "15";
            return this;
        }

    }
 
}
