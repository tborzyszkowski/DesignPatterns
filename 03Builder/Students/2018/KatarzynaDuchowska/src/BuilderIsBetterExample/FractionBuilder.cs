using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class FractionBuilder
    {
        protected Fraction fraction;

        public FractionBuilder()
        {
            fraction = new Fraction();
        }

        public FractionBuilder WithNominator(int nominator)
        {
            fraction.Nominator = nominator;
            return this;
        }

        public FractionBuilder WithDenominator(int denominator)
        {
            fraction.Denominator = denominator;
            return this;
        }

        public Fraction Build()
        {
            return fraction;
        }
    }
}
