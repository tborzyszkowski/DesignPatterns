using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Controllers
{
    public interface IMoneyController
    {
        bool CheckIfPlayerHasMoney(string name, PlayerController playerController);
        (Player, Player) DonateMoney(string donatorName, string recipientName, PlayerController playerController);
    }
}
