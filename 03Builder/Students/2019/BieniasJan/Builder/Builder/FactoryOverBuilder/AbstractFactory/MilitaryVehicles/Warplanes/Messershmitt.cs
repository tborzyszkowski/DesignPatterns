namespace Builder.FactoryOverBuilder.AbstractFactory.MilitaryVehicles.Warplanes
{
    public sealed class Messerschmitt : Warplane
    {
        public Messerschmitt()
        {
            WarplaneType = WarplaneType.Fighter;
            Name = "Messerschmitt Bf 109";
            Nationality = Nation.Germany;
            HitPoints = 200;
            Price = 319_000;
            YearOfProduction = 1937;
            AmmoCapacity = 1100;
            Speed = 530;
        }
    }
}
