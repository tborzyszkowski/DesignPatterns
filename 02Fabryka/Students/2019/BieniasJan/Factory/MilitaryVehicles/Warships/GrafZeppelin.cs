namespace Factory.MilitaryVehicles.Warships
{
    public sealed class GrafZeppelin : Warship
    {
        public GrafZeppelin()
        {
            WarshipType = WarshipType.AircraftCarrier;
            Name = "Graf Zeppelin";
            Nationality = Nation.Germany;
            HitPoints = 52_600;
            Price = 1_000_000;
            YearOfProduction = 1938;
            AmmoCapacity = 21333;
            Speed = 32;
        }
    }
}
