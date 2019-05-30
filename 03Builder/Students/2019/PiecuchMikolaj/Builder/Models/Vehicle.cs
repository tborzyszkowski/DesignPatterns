using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Models
{
    public enum VehicleType
    {
        Passenger,
        Delivery
    }

    public class Vehicle
    {
        public VehicleType Type { get; set; }
        public int Wheels { get; set; }
        public string Engine { get; set; }
        public decimal MaxLoad { get; set; }
        public int Doors { get; set; }
        public int MaxSpeed { get; set; }
    }
}
