using System;

namespace Factory.MilitaryVehicles.Warplanes
{
    public enum WarplaneType
    {
        Fighter,
        HeavyFighter,
        MultiroleFighter,
        Bomber
    }

    public abstract class Warplane : IMilitaryVehicle
    {
        //Property tylko dla Warplane
        public WarplaneType WarplaneType { get; protected set; }

        //Metoda tylko dla Warplane
        public void Fly()
        {
            Console.WriteLine("Flying a " + Name + "(" + WarplaneType + ")" + " warplane...");
        }

        //Implementacja interfejsu IMilitaryVehicle
        public Nation Nationality { get; protected set; }
        public string Name { get; protected set; }
        public int HitPoints { get; protected set; }
        public int Price { get; protected set; }
        public int YearOfProduction { get; protected set; }
        public int AmmoCapacity { get; protected set; }
        public int Speed { get; protected set; }

        public void Reload()
        {
            Console.WriteLine("Reloading " + Name + " (" + WarplaneType + ")" + " warplane...");
        }

        public void Repair()
        {
            Console.WriteLine("Repairing " + Name + " (" + WarplaneType + ")" + " warplane...");
        }

        public void Shoot()
        {
            Console.WriteLine(Name + " (" + WarplaneType + ")" + " warplane is shooting...");
        }
        //

        public override string ToString()
        {
            return "WARPLANE (" + WarplaneType + "):\nName: " + Name + ", Nationality: " + Nationality + ", HP : " + HitPoints + ", Price: " + Price +
                ", Year of prod.: " + YearOfProduction + ", Ammo capacity: " + AmmoCapacity + ", Speed: " + Speed;
        }
    }
}
