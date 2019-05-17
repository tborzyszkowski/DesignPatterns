using GunStore.Enums;

namespace GunStore.Builder
{
    //Concrete Builder
    public class MP5Builder : GunBuilder
    {
        public MP5Builder()
        {
            _gun = CreateNewGun();
        }

        public override Gun CreateNewGun()
        {
            return new Gun() { Name = "HK MP5" };
        }

        public override GunBuilder SetCaliber()
        {
            _gun.Caliber = "9×19mm Parabellum";
            return this;
        }

        public override GunBuilder SetDesigner()
        {
            _gun.Designer = "Helmut Baureuter";
            return this;
        }

        public override GunBuilder SetGunType()
        {
            _gun.Type = GunType.SMG;
            return this;
        }

        public override GunBuilder SetManufacturer()
        {
            _gun.Manufacturer = "Heckler & Koch";
            return this;
        }

        public override GunBuilder SetMass()
        {
            _gun.Mass = 2.7m;
            return this;
        }

        public override GunBuilder SetMuzzleVelocity()
        {
            _gun.MuzzleVelocity = 400;
            return this;
        }

        public override GunBuilder SetNation()
        {
            _gun.Nation = Nation.Germany;
            return this;
        }

        public override GunBuilder SetBasePrice()
        {
            _gun.BasePrice = 1699.99m;
            return this;
        }

        public override GunBuilder SetRateOfFire()
        {
            _gun.RateOfFire = 800;
            return this;
        }
    }
}
