namespace Builder.BuilderOverFactory.FluentBuilder
{
    public class DodgeViperBuilder : DodgeBuilder
    {
        public DodgeViperBuilder()
        {
            _dodge = CreateNewDodge();
        }

        public override Dodge CreateNewDodge()
        {
            return new Dodge() { Name = "1996 Dodge Viper GTS" };
        }

        public override DodgeBuilder SetEngine()
        {
            _dodge.Engine = "Viper Engine";
            return this;
        }

        public override DodgeBuilder SetPrice()
        {
            _dodge.Price = 250_000;
            return this;
        }

        public override DodgeBuilder SetTopSpeed()
        {
            _dodge.TopSpeed = 280;
            return this;
        }

        public override DodgeBuilder SetYearOfProduction()
        {
            _dodge.YearOfProduction = 1996;
            return this;
        }
    }
}
