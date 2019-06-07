using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Cruisers
{
    public sealed class Destra : Cruiser
    {
        public Destra()
        {
            Model = CruisersType.Heavy_Combat;
            Armored = Armor.Very_Heavy;
            Name = "Destra Crusader";
            Race = Fraction.Advent;
            Hp = 775;
            Shields = 825;
            Cost = 525;
            MainWeapon = "Plasma";
            Dmg = 19;
        }
    }
}
