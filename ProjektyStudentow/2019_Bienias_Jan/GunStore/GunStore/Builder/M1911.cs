using GunStore.Enums;

namespace GunStore.Builder
{
    //Concrete Builder
    public class M1911Builder : GunBuilder
    {
        public M1911Builder()
        {
            _gun = CreateNewGun();
        }

        public override Gun CreateNewGun()
        {
            return new Gun() { Name = "Colt M1911" };
        }

        public override GunBuilder SetCaliber()
        {
            _gun.Caliber = ".45 ACP";
            return this;
        }

        public override GunBuilder SetDesigner()
        {
            _gun.Designer = "John Browning";
            return this;
        }

        public override GunBuilder SetGunType()
        {
            _gun.Type = GunType.Handgun;
            return this;
        }

        public override GunBuilder SetManufacturer()
        {
            _gun.Manufacturer = "Colt Manufacturing Company";
            return this;
        }

        public override GunBuilder SetMass()
        {
            _gun.Mass = 1.1m;
            return this;
        }

        public override GunBuilder SetMuzzleVelocity()
        {
            _gun.MuzzleVelocity = 253;
            return this;
        }

        public override GunBuilder SetNation()
        {
            _gun.Nation = Nation.USA;
            return this;
        }

        public override GunBuilder SetBasePrice()
        {
            _gun.BasePrice = 499.99m;
            return this;
        }

        public override GunBuilder SetRateOfFire()
        {
            _gun.RateOfFire = 310;
            return this;
        }
    }
}
