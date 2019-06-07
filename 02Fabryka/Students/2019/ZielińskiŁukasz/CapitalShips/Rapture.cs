using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.CapitalShips
{
    public sealed class Rapture : CapitalShip
    {
        public Rapture()
        {
            Model = CapitalShipsType.Support;
            Armored = Armor.Capital;
            Name = "Rapture Battlecruiser";
            Race = Fraction.Advent;
            Hp = 2415;
            Shields = 1869;
            Cost = 3000;
            MainWeapon = "Laser";
            Dmg = 12;
        }
    }
}
