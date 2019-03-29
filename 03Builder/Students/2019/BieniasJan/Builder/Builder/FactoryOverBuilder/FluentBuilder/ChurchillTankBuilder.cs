using Builder.FactoryOverBuilder.FluentBuilder.MilitaryVehicles;
using Builder.FactoryOverBuilder.FluentBuilder.MilitaryVehicles.Tanks;

namespace Builder.FactoryOverBuilder.FluentBuilder
{
    public class ChurchillTankBuilder : TankBuilder
    {
        public ChurchillTankBuilder()
        {
            _tank = CreateNewTank();
        }

        public Tank GetTank()
        {
            return _tank;
        }

        public override Tank CreateNewTank()
        {
            return new Tank { Name = "Churchill Mk IV" };
        }

        public override TankBuilder SetAmmoCapacity()
        {
            _tank.AmmoCapacity = 124;
            return this;
        }

        public override TankBuilder SetType()
        {
            _tank.TankType = TankType.Heavy;
            return this;
        }

        public override TankBuilder SetHitPoints()
        {
            _tank.HitPoints = 780;
            return this;
        }

        public override TankBuilder SetMaxSpeed()
        {
            _tank.Speed = 24;
            return this;
        }

        public override TankBuilder SetNationality()
        {
            _tank.Nationality = Nation.UK;
            return this;
        }

        public override TankBuilder SetPrice()
        {
            _tank.Price = 563_500;
            return this;
        }

        public override TankBuilder SetYearOfProduction()
        {
            _tank.YearOfProduction = 1940;
            return this;
        }
    }
}
