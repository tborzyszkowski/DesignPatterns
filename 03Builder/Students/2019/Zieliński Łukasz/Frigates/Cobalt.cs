using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Abstract;

namespace Builder.Frigates
{
    public sealed class Cobalt : Frigate
    {
        public Cobalt()
        {
            Model = FrigateType.Light;
            Armored = Armor.Medium;
            Name = "Cobalt Light Frigate";
            Race = Fraction.TEC;
            Hp = 635;
            Shields = 370;
            Cost = 300;
            MainWeapon = "Laser";
            Dmg = 10;
        }
    }
}
