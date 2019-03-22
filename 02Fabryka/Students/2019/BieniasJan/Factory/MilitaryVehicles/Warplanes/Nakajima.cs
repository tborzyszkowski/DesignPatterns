namespace Factory.MilitaryVehicles.Warplanes
{
    public sealed class Nakajima : Warplane
    {
        public Nakajima()
        {
            WarplaneType = WarplaneType.Fighter;
            Name = "Nakajima A4N";
            Nationality = Nation.Japan;
            HitPoints = 80;
            Price = 3_800;
            YearOfProduction = 1935;
            AmmoCapacity = 574;
            Speed = 330;
        }
    }
}
