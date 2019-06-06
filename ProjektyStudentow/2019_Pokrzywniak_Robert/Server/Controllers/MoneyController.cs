using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Controllers
{
    public class MoneyController : IMoneyController
    {      
        public bool CheckIfPlayerHasMoney(string name, PlayerController playerController)
        {
            var player = playerController.FindPlayerByName(name);
            if (player == null)
                return false;

            return player.Money > 0;
        }

        public (Player,Player) DonateMoney(string donatorName, string recipientName, PlayerController playerController)
        {
            var donator = playerController.FindPlayerByName(donatorName);
            var recipient = playerController.FindPlayerByName(recipientName);
            if (donator == null || recipient == null)
                return (donator,recipient);

            recipient.Money += donator.Money;
            donator.Money = 0;

            return (donator, recipient);
        }
    }
}
