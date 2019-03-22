namespace Factory.MilitaryVehicles.Warships
{
    public sealed class Oleg : Warship
    {
        public Oleg()
        {
            WarshipType = WarshipType.Cruiser;
            Name = "Oleg";
            Nationality = Nation.USSR;
            HitPoints = 24_500;
            Price = 565_000;
            YearOfProduction = 1904;
            AmmoCapacity = 1503;
            Speed = 24;
        }
    }
}
