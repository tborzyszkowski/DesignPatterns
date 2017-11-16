namespace BuilderExample
{
    public class MarineBuilder : UnitBuilder
    {
        public MarineBuilder()
        {
            unit = new Unit();
        }

        public override UnitBuilder SetArmorPoints(int armorPoints)
        {
            unit.Armor = armorPoints;
            return this;
        }

        public override UnitBuilder SetAttackPoints(int attackPoints)
        {
            unit.Attack = attackPoints;
            return this;
        }

        public override UnitBuilder SetHealthPoints(int healthPoints)
        {
            unit.Health = healthPoints;
            return this;
        }

        public override UnitBuilder SetName(string name)
        {
            unit.Name = name;
            return this;
        }

        public override UnitBuilder SetSize(int size)
        {
            unit.Size = size;
            return this;
        }
    }
}
