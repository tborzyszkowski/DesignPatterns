using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builder1
{
    public abstract class Builder1
    {
        protected Frigate1 frigate;
        public Frigate1 ship { get => frigate; }
        public abstract Frigate1 CreateNewShip(); //testing reasons
        //public abstract Builder1 SetName();
        public abstract Builder1 SetModel();
        public abstract Builder1 SetArmor();
        public abstract Builder1 SetRace();
        public abstract Builder1 SetHp();
        public abstract Builder1 SetCost();
        public abstract Builder1 SetDmg();
        public abstract Builder1 SetMainWeapon();
        public abstract Builder1 SetShields();

        public static implicit operator Frigate1(Builder1 BuildShip)
        {
            return BuildShip.SetModel()
                .SetArmor()
                .SetRace()
                .SetHp()
                .SetCost()
                .SetDmg()
                .SetMainWeapon()
                .SetShields()
                .ship;
        }
    }
}
