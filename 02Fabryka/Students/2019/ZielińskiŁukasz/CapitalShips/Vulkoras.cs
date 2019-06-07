using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.CapitalShips
{
    public sealed class Vulkoras : CapitalShip
    {
        public Vulkoras()
        {
            Model = CapitalShipsType.Heavy_Assault;
            Armored = Armor.Capital;
            Name = "Vulkoras Desolator";
            Race = Fraction.Vassari;
            Hp = 2651;
            Shields = 1418;
            Cost = 3000;
            MainWeapon = "Phase Missile";
            Dmg = 29;
        }
    }
}
