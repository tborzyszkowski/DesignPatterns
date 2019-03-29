using System;

namespace Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Warplanes
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
        public WarplaneType WarplaneType { get; set; }

        //Metoda tylko dla Warplane
        public void Fly()
        {
            Console.WriteLine("Flying a " + Name + "(" + WarplaneType + ")" + " warplane...");
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
