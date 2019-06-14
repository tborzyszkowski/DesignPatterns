using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Abstract;

namespace Builder.Frigates
{
    public sealed class Karrastra : Frigate
    {
        public Karrastra()
        {
            Model = FrigateType.Siege;
            Armored = Armor.Light;
            Name = "Karrastra Destructor";
            Race = Fraction.Vassari;
            Hp = 475;
            Shields = 285;
            Cost = 625;
            MainWeapon = "Planetary Assault Beam";
            Dmg = 33;
        }
    }
}
