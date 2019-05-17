using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.CapitalShips
{
    public sealed class Discord : CapitalShip
    {
        public Discord()
        {
            Model = CapitalShipsType.Unique;
            Armored = Armor.Capital;
            Name = "Discord Battleship";
            Race = Fraction.Advent;
            Hp = 2168;
            Shields = 1654;
            Cost = 3000;
            MainWeapon = "Plazma";
            Dmg = 17;
        }
    }
}
