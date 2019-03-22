using Factory.MilitaryVehicles.Tanks;
using Factory.MilitaryVehicles.Warplanes;
using Factory.MilitaryVehicles.Warships;

//Client Code
namespace Factory.SimpleFactory
{
    public class VehicleFactory
    {
        private SimpleFactory _factory;

        public VehicleFactory()
        {
            _factory = SimpleFactory.Instance;
        }

        public Tank BuildTank(string name)
        {
            Tank tank = _factory.CreateTank(name);
            if (tank == null)
                return null;
            //tank.Drive();
            //tank.Shoot();
            //tank.Reload();
            //tank.Repair();
            return tank;
        }

        public Warship BuildWarship(string name)
        {
            Warship warship = _factory.CreateWarship(name);
            if (warship == null)
                return null;
            warship.Swim();
            warship.Shoot();
            warship.Reload();
            warship.Repair();
            return warship;
        }

        public Warplane BuildWarplane(string name)
        {
            Warplane warplane = _factory.CreateWarplane(name);
            if (warplane == null)
                return null;
            warplane.Fly();
            warplane.Shoot();
            warplane.Reload();
            warplane.Repair();
            return warplane;

        }
    }
}
