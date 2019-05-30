using Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders
{
    public class TypeVehicleBuilder<T> : SpeedVehicleBuilder<TypeVehicleBuilder<T>> where T : TypeVehicleBuilder<T>
    {
        public T SetType(VehicleType type)
        {
            vehicle.Type = VehicleType.Delivery;
            return this as T;
        }
    }
}
