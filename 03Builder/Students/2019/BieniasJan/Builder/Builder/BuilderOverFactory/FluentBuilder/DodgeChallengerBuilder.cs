namespace Builder.BuilderOverFactory.FluentBuilder
{
    public class DodgeChallengerBuilder : DodgeBuilder
    {
        public DodgeChallengerBuilder()
        {
            _dodge = CreateNewDodge();
        }

        public override Dodge CreateNewDodge()
        {
            return new Dodge() { Name = "1970 Dodge Challenger R/T" };
        }

        public override DodgeBuilder SetEngine()
        {
            _dodge.Engine = "Challenger Engine";
            return this;
        }

        public override DodgeBuilder SetPrice()
        {
            _dodge.Price = 100_000;
            return this;
        }

        public override DodgeBuilder SetTopSpeed()
        {
            _dodge.TopSpeed = 250;
            return this;
        }

        public override DodgeBuilder SetYearOfProduction()
        {
            _dodge.YearOfProduction = 1970;
            return this;
        }
    }
}
