using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.CapitalShips
{
    public sealed class Jarrasul : CapitalShip
    {
        public Jarrasul()
        {
            Model = CapitalShipsType.Mothership;
            Armored = Armor.Capital;
            Name = "Jarrasul Evacuator";
            Race = Fraction.Vassari;
            Hp = 3220;
            Shields = 1323;
            Cost = 3000;
            MainWeapon = "Wave";
            Dmg = 14;
        }
    }
}
