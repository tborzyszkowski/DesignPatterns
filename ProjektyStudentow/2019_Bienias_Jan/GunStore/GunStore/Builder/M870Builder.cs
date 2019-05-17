using GunStore.Enums;

namespace GunStore.Builder
{
    //Concrete Builder
    public class M870Builder : GunBuilder
    {
        public M870Builder()
        {
            _gun = CreateNewGun();
        }

        public override Gun CreateNewGun()
        {
            return new Gun() { Name = "Remington M870" };
        }

        public override GunBuilder SetCaliber()
        {
            _gun.Caliber = "12 gauge";
            return this;
        }

        public override GunBuilder SetDesigner()
        {
            _gun.Designer = "Phillip Haskell";
            return this;
        }

        public override GunBuilder SetGunType()
        {
            _gun.Type = GunType.Shotgun;
            return this;
        }

        public override GunBuilder SetManufacturer()
        {
            _gun.Manufacturer = "Remington Arms";
            return this;
        }

        public override GunBuilder SetMass()
        {
            _gun.Mass = 3.2m;
            return this;
        }

        public override GunBuilder SetMuzzleVelocity()
        {
            _gun.MuzzleVelocity = 450;
            return this;
        }

        public override GunBuilder SetNation()
        {
            _gun.Nation = Nation.USA;
            return this;
        }

        public override GunBuilder SetBasePrice()
        {
            _gun.BasePrice = 1199.99m;
            return this;
        }

        public override GunBuilder SetRateOfFire()
        {
            _gun.RateOfFire = 92;
            return this;
        }
    }
}
