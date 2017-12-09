namespace BuilderExample
{
    public abstract class UnitBuilder
    {
        protected Unit Unit { get; set; }

        public abstract UnitBuilder SetName();
        public abstract UnitBuilder SetArmorPoints();
        public abstract UnitBuilder SetHealthPoints();
        public abstract UnitBuilder SetAttackPoints();
        public abstract UnitBuilder SetSize();

        public static implicit operator Unit(UnitBuilder builder)
        {
            return builder.SetName().SetArmorPoints().SetHealthPoints().SetAttackPoints().SetSize().Unit;
        }
    }
}
