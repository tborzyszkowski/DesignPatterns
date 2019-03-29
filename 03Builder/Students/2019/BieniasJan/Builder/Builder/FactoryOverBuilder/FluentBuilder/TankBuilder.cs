using Builder.FactoryOverBuilder.FluentBuilder.MilitaryVehicles.Tanks;

namespace Builder.FactoryOverBuilder.FluentBuilder
{
    //Fluent Builder Interface -> allows method chaining
    public abstract class TankBuilder
    {
        protected Tank _tank;
        public Tank Tank { get => _tank; }
        public abstract Tank CreateNewTank(); //testing reasons
        //public abstract TankBuilder SetName();
        public abstract TankBuilder SetType();
        public abstract TankBuilder SetNationality();
        public abstract TankBuilder SetHitPoints();
        public abstract TankBuilder SetPrice();
        public abstract TankBuilder SetYearOfProduction();
        public abstract TankBuilder SetAmmoCapacity();
        public abstract TankBuilder SetMaxSpeed();

        //Such an implicit operator means you can convert TankBuilder to Tank implicitly.
        public static implicit operator Tank(TankBuilder tankBuilder)
        {
            return tankBuilder.SetAmmoCapacity()
                .SetHitPoints()
                .SetNationality()
                .SetPrice()
                .SetType()
                .SetYearOfProduction()
                .SetMaxSpeed()
                .Tank;
        }
    }
}
