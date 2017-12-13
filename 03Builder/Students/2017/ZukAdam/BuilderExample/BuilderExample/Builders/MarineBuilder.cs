namespace BuilderExample
{
    public class MarineBuilder : UnitBuilder
    {
        public MarineBuilder()
        {
            this.Unit = new Unit();
        }

        public override UnitBuilder SetArmorPoints()
        {
            this.Unit.Armor = 10;
            return this;
        }

        public override UnitBuilder SetAttackPoints()
        {
            this.Unit.Attack = 5;
            return this;
        }

        public override UnitBuilder SetHealthPoints()
        {
            this.Unit.Health = 100;
            return this;
        }

        public override UnitBuilder SetName()
        {
            this.Unit.Name = "Marine";
            return this;
        }

        public override UnitBuilder SetSize()
        {
            this.Unit.Size = 1;
            return this;
        }
    }
}
