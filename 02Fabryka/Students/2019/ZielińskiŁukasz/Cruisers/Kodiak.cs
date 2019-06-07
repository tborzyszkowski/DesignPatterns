using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Cruisers
{
    public sealed class Kodiak : Cruiser
    {
        public Kodiak()
        {
            Model = CruisersType.Heavy_Combat;
            Armored = Armor.Very_Heavy;
            Name = "Kodiak Heavy Cruiser";
            Race = Fraction.TEC;
            Hp = 1050;
            Shields = 600;
            Cost = 500;
            MainWeapon = "Autocannon";
            Dmg = 18;
        }
    }
}
