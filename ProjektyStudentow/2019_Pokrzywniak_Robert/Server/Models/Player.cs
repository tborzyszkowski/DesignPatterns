using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class Player : Prototype<Player>
    {
        public string Name { get; set; }
        public int Money { get; set; }
    }
}
