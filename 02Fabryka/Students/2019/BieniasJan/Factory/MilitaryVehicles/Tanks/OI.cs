namespace Factory.MilitaryVehicles.Tanks
{
    public sealed class OI : Tank
    {
        public OI()
        {
            TankType = TankType.Heavy;
            Name = "O-I";
            Nationality = Nation.Japan;
            HitPoints = 950;
            Price = 950_000;
            YearOfProduction = 1939;
            AmmoCapacity = 100;
            Speed = 30;
        }
    }
}
