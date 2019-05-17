using System;

namespace Factory.CapitalShips
{

    public abstract class CapitalShip : Ships
    {

        public enum CapitalShipsType
        {
            Battleship,
            Carrier,
            Mothership,
            Support,
            Heavy_Assault,
            Unique
        }

        public CapitalShipsType Model { get; protected set; }
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