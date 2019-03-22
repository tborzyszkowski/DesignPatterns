using System;

namespace Factory.MilitaryVehicles.Tanks
{
    public enum TankType
    {
        Light,
        Medium,
        Heavy,
        TankDestroyer,
        SPG //Self-Propelled Guns
    }

    public abstract class Tank : IMilitaryVehicle
    {
        //Property tylko dla Tank
        public TankType TankType { get; protected set; }

        //Metoda tylko dla Tank
        public void Drive()
        {
            Console.WriteLine("Driving a " + Name + "(" + TankType + ")" + " tank...");
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
            Console.WriteLine("Reloading " + Name + " (" + TankType + ")" + " tank...");
        }

        public void Repair()
        {
            Console.WriteLine("Repairing " + Name + " (" + TankType + ")" + " tank...");
        }

        public void Shoot()
        {
            Console.WriteLine(Name + " (" + TankType + ")" + " tank is shooting...");
        }
        //

        public override string ToString()
        {
            return "TANK (" + TankType + "):\nName: " + Name + ", Nationality: " + Nationality + ", HP : " + HitPoints + ", Price: " + Price +
                ", Year of prod.: " + YearOfProduction + ", Ammo capacity: " + AmmoCapacity + ", Speed: " + Speed;
        }
    }
}
