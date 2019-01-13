using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Fraction
    {
        public int Nominator { get; set; }
        public int Denominator { get; set; }

        public double Calculate()
        {
            return Nominator / Denominator;
        }
    }
}
