using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Cruisers
{
    public sealed class Skarovas : Cruiser
    {
        public Skarovas()
        {
            Model = CruisersType.Heavy_Combat;
            Armored = Armor.Very_Heavy;
            Name = "Skarovas Enforcer";
            Race = Fraction.Vassari;
            Hp = 1180;
            Shields = 700;
            Cost = 625;
            MainWeapon = "Wave";
            Dmg = 23;
        }
    }
}
