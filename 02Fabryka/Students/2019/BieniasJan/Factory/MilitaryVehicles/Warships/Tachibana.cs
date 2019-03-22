namespace Factory.MilitaryVehicles.Warships
{
    public sealed class Tachibana : Warship
    {
        public Tachibana()
        {
            WarshipType = WarshipType.Destroyer;
            Name = "Tachibana";
            Nationality = Nation.Japan;
            HitPoints = 37_000;
            Price = 445_000;
            YearOfProduction = 1943;
            AmmoCapacity = 1211;
            Speed = 30;
        }
    }
}
