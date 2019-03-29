namespace Builder.BuilderOverFactory.AbstractFactory
{
    public class DodgeCharger : Dodge
    {
        public DodgeCharger()
        {
            Name = "1969 Dodge Charger";
            Price = 142_000;
            YearOfProduction = 1969;
            TopSpeed = 233;
            Engine = "Charger Engine";
        }
    }
}
