namespace Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Tanks
{
    public class Sherman : Tank
    {
        public Sherman()
        {
            TankType = TankType.Medium;
            Name = "Sherman III";
            Nationality = Nation.UK;
            HitPoints = 425;
            Price = 425_500;
            YearOfProduction = 1937;
            AmmoCapacity = 156;
            Speed = 26;
        }
    }
}
