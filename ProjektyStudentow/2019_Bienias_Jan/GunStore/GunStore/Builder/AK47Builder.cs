using GunStore.Enums;

namespace GunStore.Builder
{
    //Concrete Builder
    public class AK47Builder : GunBuilder
    {
        public AK47Builder()
        {
            _gun = CreateNewGun();
        }

        public override Gun CreateNewGun()
        {
            return new Gun() { Name = "AK-47" };
        }

        public override GunBuilder SetCaliber()
        {
            _gun.Caliber = "7.62 mm";
            return this;
        }

        public override GunBuilder SetDesigner()
        {
            _gun.Designer = "Mikhail Kalashnikov";
            return this;
        }

        public override GunBuilder SetGunType()
        {
            _gun.Type = GunType.Rifle;
            return this;
        }

        public override GunBuilder SetManufacturer()
        {
            _gun.Manufacturer = "Kalashnikov Concern";
            return this;
        }

        public override GunBuilder SetMass()
        {
            _gun.Mass = 3.47m;
            return this;
        }

        public override GunBuilder SetMuzzleVelocity()
        {
            _gun.MuzzleVelocity = 715;
            return this;
        }

        public override GunBuilder SetNation()
        {
            _gun.Nation = Nation.USSR;
            return this;
        }

        public override GunBuilder SetBasePrice()
        {
            _gun.BasePrice = 2699.99m;
            return this;
        }

        public override GunBuilder SetRateOfFire()
        {
            _gun.RateOfFire = 600;
            return this;
        }
    }
}
