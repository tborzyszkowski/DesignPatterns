namespace Factory.MilitaryVehicles.Warships
{
    public sealed class Valkyrie : Warship
    {
        public Valkyrie()
        {
            WarshipType = WarshipType.Destroyer;
            Name = "HMS Valkyrie";
            Nationality = Nation.UK;
            HitPoints = 8_600;
            Price = 255_000;
            YearOfProduction = 1916;
            AmmoCapacity = 3553;
            Speed = 34;
        }
    }
}
