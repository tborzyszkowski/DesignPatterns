using Newtonsoft.Json;
using Player.Models;
using Server;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player.Services
{
    class ConnectionLogin : ConnectionStrategy
    {
        public override void Run(Me player)
        {
            var serializedPlayer = JsonConvert.SerializeObject(player);
            var deserializedPlayer = JsonConvert.DeserializeObject<Me>(ServerEngine.Instance.LogIn(serializedPlayer));
            player.Name = deserializedPlayer.Name;
            player.Money = deserializedPlayer.Money;
        }
    }
}
