using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Frigates
{
    public sealed class Illuminator : Frigate
    {
        public Illuminator()
        {
            Model = FrigateType.Long_Range;
            Armored = Armor.Light;
            Name = "Illuminator Vessel";
            Race = Fraction.Advent;
            Hp = 620;
            Shields = 550;
            Cost = 380;
            MainWeapon = "Beam";
            Dmg = 10;
        }
    }
}
