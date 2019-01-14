using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCar.Model
{
    public enum Type
    {
        S2,
        S3,
        S6
    }

    public enum Currency
    {
        Kmh,
        Mph
    }
    
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Speed { get; set; }
        public string Battery { get; set; }
    }
}
