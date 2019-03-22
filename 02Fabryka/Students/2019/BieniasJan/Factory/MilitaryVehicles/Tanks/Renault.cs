namespace Factory.MilitaryVehicles.Tanks
{
    public sealed class Renault : Tank
    {
        public Renault()
        {
            TankType = TankType.SPG;
            Name = "Renault FT 75 BS";
            Nationality = Nation.France;
            HitPoints = 80;
            Price = 3700;
            YearOfProduction = 1917;
            AmmoCapacity = 24;
            Speed = 19;
        }
    }
}
