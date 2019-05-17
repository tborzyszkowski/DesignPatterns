using System;

namespace Factory.Cruisers
{

    public abstract class Cruiser : Ships
    {

        public enum CruisersType
        {
            Heavy_Combat,
            Offensive_Support,
            Defensive_Support,
            Carrier
        }

        public CruisersType Model { get; protected set; }
        public Armor Armored { get; protected set; }
        public Fraction Race { get; protected set; }
        public string Name { get; protected set; }
        public int Hp { get; protected set; }
        public int Cost { get; protected set; }
        public int Dmg { get; protected set; }
        public string MainWeapon { get; protected set; }
        public int Shields { get; protected set; }


        
    }
}