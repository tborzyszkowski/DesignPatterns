using Builder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders
{
    public abstract class VehicleBuilder<T> where T : VehicleBuilder<T>
    {
        public Vehicle Vehicle => vehicle;

        protected Vehicle vehicle;

        public VehicleBuilder()
        {
            vehicle = new Vehicle();
        }

        public static implicit operator Vehicle(VehicleBuilder<T> builder)
        {
            return builder.Vehicle;
        }
    }
}
