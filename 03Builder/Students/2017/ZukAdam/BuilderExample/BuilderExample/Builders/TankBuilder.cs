namespace BuilderExample
{
    public class TankBuilder : UnitBuilder
    {
        public TankBuilder()
        {
            this.Unit = new Unit();
        }

        public override UnitBuilder SetArmorPoints()
        {
            this.Unit.Armor = 100;
            return this;
        }

        public override UnitBuilder SetAttackPoints()
        {
            this.Unit.Attack = 150;
            return this;
        }

        public override UnitBuilder SetHealthPoints()
        {
            this.Unit.Health = 1000;
            return this;
        }

        public override UnitBuilder SetName()
        {
            this.Unit.Name = "Tank";
            return this;
        }

        public override UnitBuilder SetSize()
        {
            this.Unit.Size = 5;
            return this;
        }
    }
}
