namespace GunStore.Builder
{
    //Abs. Builder
    public abstract class GunBuilder
    {
        protected Gun _gun;
        public Gun Gun { get => _gun; }
        public abstract Gun CreateNewGun();
        public abstract GunBuilder SetGunType();
        public abstract GunBuilder SetNation();
        public abstract GunBuilder SetBasePrice();
        public abstract GunBuilder SetDesigner();
        public abstract GunBuilder SetManufacturer();
        public abstract GunBuilder SetMuzzleVelocity();
        public abstract GunBuilder SetRateOfFire();
        public abstract GunBuilder SetCaliber();
        public abstract GunBuilder SetMass();

        public static implicit operator Gun(GunBuilder gunBuilder)
        {
            return gunBuilder
                .SetGunType()
                .SetNation()
                .SetBasePrice()
                .SetDesigner()
                .SetManufacturer()
                .SetMuzzleVelocity()
                .SetRateOfFire()
                .SetCaliber()
                .SetMass()
                .Gun;
        }
    }
}
