namespace Builder.BuilderOverFactory.FluentBuilder
{
    public abstract class DodgeBuilder
    {
        protected Dodge _dodge;
        public Dodge Dodge { get => _dodge; }
        public abstract Dodge CreateNewDodge(); //testing reasons
        //public abstract DodgeBuilder SetName();
        public abstract DodgeBuilder SetTopSpeed();
        public abstract DodgeBuilder SetYearOfProduction();
        public abstract DodgeBuilder SetEngine();
        public abstract DodgeBuilder SetPrice();

        public static implicit operator Dodge(DodgeBuilder macBookBuilder)
        {
            return macBookBuilder.SetTopSpeed()
                .SetYearOfProduction()
                .SetEngine()
                .SetPrice()
                .Dodge;
        }
    }
}
