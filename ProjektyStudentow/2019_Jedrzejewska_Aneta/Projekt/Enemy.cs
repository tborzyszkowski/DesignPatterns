using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Enemy : AbstractCharacter //Adapter
    {
        Random random = new Random();
        int r;
        public Enemy(string enemysName)
        {
            name = enemysName;
            health = 50;
            SetWeapon();
        }

        public void SetHealth(int amount)
        {
            health = amount;
        }

        public int GetHealth()
        {
            return health;
        }

        private void SetWeapon()
        {
            r = random.Next(0, 2);
            if (r == 0)
            {
                weaponType = WeaponType.Axe;
            }
            else if (r == 1)
            {
                weaponType = WeaponType.Bow;
            }
            else
            {
                weaponType = WeaponType.Sword;
            }

        }
    }
}
