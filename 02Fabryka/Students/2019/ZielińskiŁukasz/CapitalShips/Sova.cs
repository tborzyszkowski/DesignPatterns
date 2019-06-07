using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.CapitalShips
{
    public sealed class Sova : CapitalShip
    {
        public Sova()
        {
            Model = CapitalShipsType.Carrier;
            Armored = Armor.Capital;
            Name = "Sova Carrier";
            Race = Fraction.TEC;
            Hp = 2850;
            Shields = 1075;
            Cost = 3000;
            MainWeapon = "Laser";
            Dmg = 14;
        }
    }
}
