using Builder.FactoryOverBuilder.FluentBuilder.MilitaryVehicles;
using Builder.FactoryOverBuilder.FluentBuilder.MilitaryVehicles.Tanks;

namespace Builder.FactoryOverBuilder.FluentBuilder
{
    public class TigerTankBuilder : TankBuilder
    {
        public TigerTankBuilder()
        {
            _tank = CreateNewTank();
        }

        public Tank GetTank()
        {
            return _tank;
        }

        public override Tank CreateNewTank()
        {
            return new Tank { Name = "Tiger I" };
        }

        public override TankBuilder SetAmmoCapacity()
        {
            _tank.AmmoCapacity = 550;
            return this;
        }

        public override TankBuilder SetType()
        {
            _tank.TankType = TankType.Heavy;
            return this;
        }

        public override TankBuilder SetHitPoints()
        {
            _tank.HitPoints = 1150;
            return this;
        }

        public override TankBuilder SetMaxSpeed()
        {
            _tank.Speed = 45;
            return this;
        }

        public override TankBuilder SetNationality()
        {
            _tank.Nationality = Nation.Germany;
            return this;
        }

        public override TankBuilder SetPrice()
        {
            _tank.Price = 2_000_000;
            return this;
        }

        public override TankBuilder SetYearOfProduction()
        {
            _tank.YearOfProduction = 1942;
            return this;
        }
    }
}
