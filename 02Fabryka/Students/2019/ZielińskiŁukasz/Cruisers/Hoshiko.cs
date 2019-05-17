using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Cruisers
{
    public sealed class Hoshiko : Cruiser
    {
        public Hoshiko()
        {
            Model = CruisersType.Defensive_Support;
            Armored = Armor.Heavy;
            Name = "Hoshiko Robotics Cruiser";
            Race = Fraction.TEC;
            Hp = 775;
            Shields = 325;
            Cost = 350;
            MainWeapon = "Laser";
            Dmg = 4;
        }
    }
}
