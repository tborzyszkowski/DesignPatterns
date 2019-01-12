using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    abstract class AbstractCharacter
    {
        protected int health;
        protected string name;
        protected WeaponType weaponType;
        int[ ] coordinates;

        public void TakeDamage()
        {
            health -= 5;
        }
        public string GetName()
        {
            return name;
        }
        public void SwitchWeapon(WeaponType newWeaponType)
        {
            weaponType = newWeaponType;
        }

        public int[ ] GetCoordinates()
        {
            return coordinates;
        }
    }
}
