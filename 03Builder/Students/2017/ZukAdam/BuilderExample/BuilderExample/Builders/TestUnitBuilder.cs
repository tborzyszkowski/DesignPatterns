namespace BuilderExample
{
    //
    // Good for test purpose
    //
    public sealed class TestUnitBuilder
    {
        private Unit Unit { get; set; }

        public TestUnitBuilder()
        {
            this.Unit = new Unit();
        }

        public TestUnitBuilder SetName(string name)
        {
            // some bussiness logic here, or just:

            this.Unit.Name = name;
            return this;
        }
        public TestUnitBuilder SetArmorPoints(int points)
        {
            // some bussiness logic here, or just:

            this.Unit.Armor = points;
            return this;
        }
        public TestUnitBuilder SetHealthPoints(int points)
        {
            // some bussiness logic here, or just:

            this.Unit.Health = points;
            return this;
        }
        public TestUnitBuilder SetAttackPoints(int points)
        {
            // some bussiness logic here, or just:

            this.Unit.Attack = points;
            return this;
        }
        public TestUnitBuilder SetSize(int size)
        {
            // some bussiness logic here, or just:

            this.Unit.Size = size;
            return this;
        }

        public Unit Build()
        {
            return this.Unit;
        }
    }
}
