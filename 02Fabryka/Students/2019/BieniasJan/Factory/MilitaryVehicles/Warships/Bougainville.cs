namespace Factory.MilitaryVehicles.Warships
{
    public class Bougainville : Warship
    {
        public Bougainville()
        {
            WarshipType = WarshipType.Cruiser;
            Name = "Bougainville";
            Nationality = Nation.France;
            HitPoints = 7_500;
            Price = 225_000;
            YearOfProduction = 1930;
            AmmoCapacity = 1331;
            Speed = 19;
        }
    }
}
