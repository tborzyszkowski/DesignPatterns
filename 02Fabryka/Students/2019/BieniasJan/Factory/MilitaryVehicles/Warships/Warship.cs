using System;

namespace Factory.MilitaryVehicles.Warships
{
    public enum WarshipType
    {
        Destroyer,
        Cruiser,
        Battleship,
        AircraftCarrier
    }

    public abstract class Warship : IMilitaryVehicle
    {
        //Property tylko dla Warplane
        protected WarshipType WarshipType { get; set; }

        //Metoda tylko dla Warplane
        public void Swim()
        {
            Console.WriteLine("Swimming a " + Name + "(" + WarshipType + ")" + " warship...");
        }

        //Implementacje interfejsu IMilitaryVehicle
        public Nation Nationality { get; protected set; }
        public string Name { get; protected set; }
        public int HitPoints { get; protected set; }
        public int Price { get; protected set; }
        public int YearOfProduction { get; protected set; }
        public int AmmoCapacity { get; protected set; }
        public int Speed { get; protected set; }

        public void Reload()
        {
            Console.WriteLine("Reloading " + Name + " (" + WarshipType + ")" + " warship...");
        }

        public void Repair()
        {
            Console.WriteLine("Repairing " + Name + " (" + WarshipType + ")" + " warship...");
        }

        public void Shoot()
        {
            Console.WriteLine(Name + " (" + WarshipType + ")" + " warship is shooting...");
        }
        //

        public override string ToString()
        {
            return "WARSHIP (" + WarshipType + "):\nName: " + Name + ", Nationality: " + Nationality + ", HP : " + HitPoints + ", Price: " + Price +
                ", Year of prod.: " + YearOfProduction + ", Ammo capacity: " + AmmoCapacity + ", Speed: " + Speed;
        }
    }
}
