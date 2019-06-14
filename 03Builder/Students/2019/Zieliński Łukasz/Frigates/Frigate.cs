using System;
using Builder.Abstract;

namespace Builder.Frigates
{
    public abstract class Frigate : Ships
    {
        public enum FrigateType
        {
            Light,
            Long_Range,
            Siege,
            AntiStrike_Craft
        }
        public FrigateType Model { get; protected set; }
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