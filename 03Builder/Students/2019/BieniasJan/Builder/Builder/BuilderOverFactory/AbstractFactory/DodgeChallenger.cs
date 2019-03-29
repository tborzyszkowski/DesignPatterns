namespace Builder.BuilderOverFactory.AbstractFactory
{
    public class DodgeChallenger : Dodge
    {
        public DodgeChallenger()
        {
            Name = "1970 Dodge Challenger R/T";
            Price = 100_000;
            YearOfProduction = 1970;
            TopSpeed = 250;
            Engine = "Challenger Engine";
        }
    }
}
