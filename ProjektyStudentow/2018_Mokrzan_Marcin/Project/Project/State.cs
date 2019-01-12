using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public abstract class State
    {
        public abstract void Handle(RoomInstance roomInstance);

        public abstract string toString();
    }
}
