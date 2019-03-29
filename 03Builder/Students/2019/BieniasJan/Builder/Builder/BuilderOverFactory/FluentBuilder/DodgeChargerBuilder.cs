namespace Builder.BuilderOverFactory.FluentBuilder
{
    public class DodgeChargerBuilder : DodgeBuilder
    {
        public DodgeChargerBuilder()
        {
            _dodge = CreateNewDodge();
        }

        public override Dodge CreateNewDodge()
        {
            return new Dodge() { Name = "1969 Dodge Charger" };
        }

        public override DodgeBuilder SetEngine()
        {
            _dodge.Engine = "Charger Engine";
            return this;
        }

        public override DodgeBuilder SetPrice()
        {
            _dodge.Price = 142_000;
            return this;
        }

        public override DodgeBuilder SetTopSpeed()
        {
            _dodge.TopSpeed = 233;
            return this;
        }

        public override DodgeBuilder SetYearOfProduction()
        {
            _dodge.YearOfProduction = 1969;
            return this;
        }
    }
}
