using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders
{
    public class VehicleDirector : TypeVehicleBuilder<VehicleDirector>
    {
        public VehicleDirector NewVehicle => new VehicleDirector();
    }
}
