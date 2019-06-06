using Player.Models;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player.Services
{
    abstract class ConnectionStrategy
    {
        public abstract void Run(Me player);
    }
}
