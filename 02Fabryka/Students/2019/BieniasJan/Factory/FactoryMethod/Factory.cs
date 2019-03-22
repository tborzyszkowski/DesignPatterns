using Factory.MilitaryVehicles;

//Abstract Creator
namespace Factory.FactoryMethod
{
    public abstract class Factory
    {
        protected abstract IMilitaryVehicle Create(string name);

        public IMilitaryVehicle Build(string name)
        {
            IMilitaryVehicle vehicle = Create(name);
            if (vehicle == null)
                return null;
            //vehicle.Shoot();
            //vehicle.Reload();
            //vehicle.Repair();
            return vehicle;
        }
    }
}
