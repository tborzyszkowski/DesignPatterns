namespace Factory.MilitaryVehicles.Tanks
{
    public sealed class Tiger : Tank
    {
        public Tiger()
        {
            TankType = TankType.Heavy;
            Name = "Tiger I";
            Nationality = Nation.Germany;
            HitPoints = 1150;
            Price = 2_000_000;
            YearOfProduction = 1942;
            AmmoCapacity = 550;
            Speed = 45;
        }
    }
}
