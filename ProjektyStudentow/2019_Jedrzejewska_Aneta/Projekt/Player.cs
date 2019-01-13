using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Player : AbstractCharacter
    {

        public Player(string playersName, WeaponType weapon)
        {
            name = playersName;
            weaponType = weapon;
            health = 100;
        }
    }
}
