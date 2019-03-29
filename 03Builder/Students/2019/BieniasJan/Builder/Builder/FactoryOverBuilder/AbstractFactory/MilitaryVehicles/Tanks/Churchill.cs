namespace Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Tanks
{
    public sealed class Churchill : Tank
    {
        public Churchill()
        {
            TankType = TankType.Heavy;
            Name = "Churchill Mk IV";
            Nationality = Nation.UK;
            HitPoints = 780;
            Price = 563_500;
            YearOfProduction = 1940;
            AmmoCapacity = 124;
            Speed = 24;
        }
    }
}
