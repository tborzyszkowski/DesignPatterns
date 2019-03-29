namespace Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles
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
        Nation Nationality { get; set; }
        string Name { get; set; }
        int HitPoints { get; set; }
        int Price { get; set; }
        int YearOfProduction { get; set; }
        int AmmoCapacity { get; set; }
        int Speed { get; set; }

        void Shoot();
        void Repair();
        void Reload();
    }
}
