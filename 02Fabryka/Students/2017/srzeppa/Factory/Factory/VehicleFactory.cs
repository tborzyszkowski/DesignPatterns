using Factory.Model;

namespace Factory
{
    public class VehicleFactory
    {

        public BaseVehicle CreateVehicle(string name)
        {
            if (name.Equals("Car"))
            {
                return new Car();
            }
            else if (name.Equals("Motorbike"))
            {
                return new Motorbike();
            }
            else if (name.Equals("Bike"))
            {
                return new Bike();
            }
            return null;
        }

    }
}
