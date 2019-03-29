namespace Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Warplanes
{
    public sealed class Spitfire : Warplane
    {
        public Spitfire()
        {
            WarplaneType = WarplaneType.Fighter;
            Name = "Supermarine Spitfire";
            Nationality = Nation.UK;
            HitPoints = 230;
            Price = 892_000;
            YearOfProduction = 1938;
            AmmoCapacity = 500;
            Speed = 585;
        }
    }
}
