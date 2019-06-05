using Newtonsoft.Json;
using Server.Controllers;
using Server.Helpers;
using Server.Models;
using System;

namespace Server
{
    public sealed class ServerEngine
    {
        private static Lazy<ServerEngine> lazy = new Lazy<ServerEngine>(() => new ServerEngine());
        public static ServerEngine Instance { get { return lazy.Value; } set { lazy = new Lazy<ServerEngine>(() => value); } }

        private readonly PlayerController _playerController;
        private readonly MoneyControllerProxy _moneyController;
        private readonly PermissionHelper _permissionHelper;
        private ServerEngine()
        {
            _playerController = PlayerController.Instance;
            _permissionHelper = new PermissionHelper();
            _moneyController = new MoneyControllerProxy(_permissionHelper);
        }

        public string LogIn(string player)
        {
            var deserializedPlayer = JsonConvert.DeserializeObject<Player>(player);
            return JsonConvert.SerializeObject(_playerController.LogIn(deserializedPlayer.Name));
        }
        public void LogOut(string player)
        {
            var deserializedPlayer = JsonConvert.DeserializeObject<Player>(player);
            _playerController.LogOut(deserializedPlayer);
        }
        public string FindPlayerbyName(string name)
        {
            return JsonConvert.SerializeObject(_playerController.FindPlayerByName(name));
        }
        public string DonateMoney(string donatorName, string recipientName)
        {
           var playerHasMoney =  _moneyController.CheckIfPlayerHasMoney(donatorName, _playerController);
            if (!playerHasMoney)
                return "ERROR: You haver no money to donate";
            var result = _moneyController.DonateMoney(donatorName, recipientName, _playerController);
            if(result.Item1 == null && result.Item2 == null)
                return "ERROR: You have no permission to donate to this person";

            return JsonConvert.SerializeObject(result);
        }
    }
}
