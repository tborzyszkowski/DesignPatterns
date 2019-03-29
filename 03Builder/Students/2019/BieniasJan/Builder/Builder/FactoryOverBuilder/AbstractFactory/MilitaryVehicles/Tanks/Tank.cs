using System;

namespace Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Tanks
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
        public TankType TankType { get; set; }

        //Metoda tylko dla Tank
        public void Drive()
        {
            Console.WriteLine("Driving a " + Name + "(" + TankType + ")" + " tank...");
        }

        //Implementacja interfejsu IMilitaryVehicle
        public Nation Nationality { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Price { get; set; }
        public int YearOfProduction { get; set; }
        public int AmmoCapacity { get; set; }
        public int Speed { get; set; }

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
