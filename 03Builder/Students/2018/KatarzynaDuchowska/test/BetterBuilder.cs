using Builder;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class BetterBuilder
    {
        [Test]
        public void CorrectFractionTest()
        {
            FractionBuilder builder = new FractionBuilder();
            Fraction fraction = builder.WithNominator(2).WithDenominator(1).Build();

            Assert.True(fraction.Calculate() == 2 / 1);
        }


        [Test]
        public void IncorrectFractionTest()
        {
            FractionBuilder builder = new FractionBuilder();
            Fraction fraction = builder.WithNominator(1).WithDenominator(0).Build();

            Assert.Throws<DivideByZeroException>(
                delegate { fraction.Calculate(); }
            );
        }
    }
}
