using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Cruisers
{
    public sealed class Stilakus : Cruiser
    {
        public Stilakus()
        {
            Model = CruisersType.Offensive_Support;
            Armored = Armor.Heavy;
            Name = "Stilakus Subverter";
            Race = Fraction.Vassari;
            Hp = 600;
            Shields = 300;
            Cost = 400;
            MainWeapon = "Pulse Gun";
            Dmg = 5;
        }
    }
}
