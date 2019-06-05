using Newtonsoft.Json;
using Player.Models;
using Server;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player.Services
{
    class ConnectionLogout : ConnectionStrategy
    {
        public override void Run(Me player)
        {
            var serializedPlayer = JsonConvert.SerializeObject(player);
            ServerEngine.Instance.LogOut(serializedPlayer);
        }
    }
}
