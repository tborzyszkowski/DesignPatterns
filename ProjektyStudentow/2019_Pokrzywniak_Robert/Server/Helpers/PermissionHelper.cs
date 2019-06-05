using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Helpers
{
    public class PermissionHelper
    {
        public bool HasPermission(Player player)
        {
            return player.Name == "Robert";
        }
    }
}
