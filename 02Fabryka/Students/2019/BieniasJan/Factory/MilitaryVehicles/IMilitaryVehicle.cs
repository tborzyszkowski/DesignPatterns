namespace Factory.MilitaryVehicles
{
    public enum Nation
    {
        UK,
        Germany,
        France,
        Japan,
        USSR
    }

    public interface IMilitaryVehicle
    {
        Nation Nationality { get; }
        string Name { get; }
        int HitPoints { get; }
        int Price { get; }
        int YearOfProduction { get; }
        int AmmoCapacity { get; }
        int Speed { get; }

        void Shoot();
        void Repair();
        void Reload();
    }
}
