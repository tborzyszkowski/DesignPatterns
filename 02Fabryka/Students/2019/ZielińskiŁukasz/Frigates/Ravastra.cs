using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Frigates
{
    public sealed class Ravastra : Frigate
    {
        public Ravastra()
        {
            Model = FrigateType.Light;
            Armored = Armor.Medium;
            Name = "Ravastra Skirmisher";
            Race = Fraction.Vassari;
            Hp = 740;
            Shields = 465;
            Cost = 420;
            MainWeapon = "Pulse Gun";
            Dmg = 12;
        }
    }
}
