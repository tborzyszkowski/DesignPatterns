using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Abstract;

namespace Builder.Frigates
{
    public sealed class Garda : Frigate
    {
        public Garda()
        {
            Model = FrigateType.AntiStrike_Craft;
            Armored = Armor.Heavy;
            Name = "Garda Flak Frigate";
            Race = Fraction.TEC;
            Hp = 765;
            Shields = 405;
            Cost = 375;
            MainWeapon = "Autocannons";
            Dmg = 3;
        }
    }
}
