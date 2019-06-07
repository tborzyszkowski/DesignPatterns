using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Frigates
{
    public sealed class Disciple : Frigate
    {
        public Disciple()
        {
            Model = FrigateType.Light;
            Armored = Armor.Medium;
            Name = "Disciple Vessel";
            Race = Fraction.Advent;
            Hp = 425;
            Shields = 450;
            Cost = 250;
            MainWeapon = "Laser";
            Dmg = 9;
        }
    }
}
