using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders
{
    public class SpeedVehicleBuilder<T> : WheelsVehicleBuilder<SpeedVehicleBuilder<T>> where T: SpeedVehicleBuilder<T>
    {
        public T SetMaxSpeed(int speed)
        {
            vehicle.MaxSpeed = speed;
            return this as T;
        }
    }
}
