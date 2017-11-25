using System;
using System.Linq.Expressions;

namespace DesignPatternsBuilder.zad2
{
    public class TestStep
    {
        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        public Expression<Func<bool>> Expression { get; set; }

        public TestStep(Expression<Func<bool>> expression)
        {
            Expression = expression;
        }
    }
}
