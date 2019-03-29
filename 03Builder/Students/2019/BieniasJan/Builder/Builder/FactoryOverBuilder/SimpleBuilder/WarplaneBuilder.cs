using Builder.FactoryOverBuilder.SimpleBuilder.MilitaryVehicles.Warplanes;

namespace Builder.FactoryOverBuilder.SimpleBuilder
{
    public abstract class WarplaneBuilder
    {
        protected Warplane _warplane;
        public Warplane Warplane { get => _warplane; }
        public abstract void SetType();
        public abstract void SetNationality();
        public abstract void SetHitPoints();
        public abstract void SetPrice();
        public abstract void SetYearOfProduction();
        public abstract void SetAmmoCapacity();
        public abstract void SetMaxSpeed();
    }
}
