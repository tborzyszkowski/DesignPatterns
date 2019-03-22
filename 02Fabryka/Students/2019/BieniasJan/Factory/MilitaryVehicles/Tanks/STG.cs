namespace Factory.MilitaryVehicles.Tanks
{
    public sealed class STG : Tank
    {
        public STG()
        {
            TankType = TankType.Medium;
            Name = "STG";
            Nationality = Nation.USSR;
            HitPoints = 1350;
            Price = 9700;
            YearOfProduction = 1949;
            AmmoCapacity = 35;
            Speed = 50;
        }
    }
}
