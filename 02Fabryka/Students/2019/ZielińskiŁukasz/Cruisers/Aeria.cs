using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Cruisers
{
    public sealed class Aeria : Cruiser
    {
        public Aeria()
        {
            Model = CruisersType.Carrier;
            Armored = Armor.Heavy;
            Name = "Aeria Drone Host";
            Race = Fraction.Advent;
            Hp = 1650;
            Shields = 1170;
            Cost = 1280;
            MainWeapon = "None";
            Dmg = 0;
        }
    }
}
