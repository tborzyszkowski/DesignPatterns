namespace Factory.MilitaryVehicles.Warplanes
{
    public sealed class Petlyakov : Warplane
    {
        public Petlyakov()
        {
            WarplaneType = WarplaneType.Bomber;
            Name = "Petlyakov Pe-8";
            Nationality = Nation.USSR;
            HitPoints = 500;
            Price = 225_000;
            YearOfProduction = 1933;
            AmmoCapacity = 21;
            Speed = 443;
        }
    }
}
