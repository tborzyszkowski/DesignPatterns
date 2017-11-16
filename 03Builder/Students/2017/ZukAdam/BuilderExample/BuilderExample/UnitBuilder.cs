namespace BuilderExample
{
    public abstract class UnitBuilder
    {
        protected Unit unit;

        Unit Unit
        {
            get { return unit; }
        }

        public abstract UnitBuilder SetName(string name);
        public abstract UnitBuilder SetArmorPoints(int armorPoints);
        public abstract UnitBuilder SetHealthPoints(int healthPoints);
        public abstract UnitBuilder SetAttackPoints(int attackPoints);
        public abstract UnitBuilder SetSize(int size);

        public static implicit operator Unit(UnitBuilder builder)
        {
            return builder.Unit;
        }
    }
}
