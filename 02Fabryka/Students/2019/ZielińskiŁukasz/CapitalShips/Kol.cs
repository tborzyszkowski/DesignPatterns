using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.CapitalShips
{
    public sealed class Kol : CapitalShip
    {
        public Kol()
        {
            Model = CapitalShipsType.Battleship;
            Armored = Armor.Capital;
            Name = "Kol Battleship";
            Race = Fraction.TEC;
            Hp = 3600;
            Shields = 1500;
            Cost = 3000;
            MainWeapon = "Beam";
            Dmg = 9;
        }
    }
}
