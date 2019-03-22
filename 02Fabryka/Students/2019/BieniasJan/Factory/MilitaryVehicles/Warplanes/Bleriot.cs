namespace Factory.MilitaryVehicles.Warplanes
{
    public sealed class Bleriot : Warplane
    {
        public Bleriot()
        {
            WarplaneType = WarplaneType.Fighter;
            Name = "Bleriot-SPAD S.510";
            Nationality = Nation.France;
            HitPoints = 165;
            Price = 20_000;
            YearOfProduction = 1935;
            AmmoCapacity = 600;
            Speed = 340;
        }
    }
}
