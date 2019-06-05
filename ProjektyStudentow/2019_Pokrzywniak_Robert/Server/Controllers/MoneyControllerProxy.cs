using System;
using System.Collections.Generic;
using System.Text;
using Server.Helpers;
using Server.Models;

namespace Server.Controllers
{
    public class MoneyControllerProxy : IMoneyController
    {
        private readonly MoneyController _moneyController;
        private readonly PermissionHelper _permissionHelper;

        public MoneyControllerProxy(PermissionHelper permissionHelper)
        {
            _moneyController = new MoneyController();
            _permissionHelper = permissionHelper;
        }

        public bool CheckIfPlayerHasMoney(string name, PlayerController playerController)
        {
            return _moneyController.CheckIfPlayerHasMoney(name, playerController);
        }

        public (Player, Player) DonateMoney(string donatorName, string recipientName, PlayerController playerController)
        {
            if (!_permissionHelper.HasPermission(playerController.FindPlayerByName(recipientName)))
                return (null,null);

            return _moneyController.DonateMoney(donatorName, recipientName, playerController);
        }
    }
}
