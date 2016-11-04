using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03FluentBuilder {
    class Shop {
        public Vehicle Construct(VehicleBuilder vehicleBuilder) {
            return vehicleBuilder;
        }
    }
}
