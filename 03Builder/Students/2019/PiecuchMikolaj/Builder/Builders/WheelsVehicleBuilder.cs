using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders
{
    public class WheelsVehicleBuilder<T> : VehicleBuilder<WheelsVehicleBuilder<T>> where T : WheelsVehicleBuilder<T>
    {
        public T SetWheels(int wheels)
        {
            vehicle.Wheels = wheels;
            return this as T;
        }
    }
}
