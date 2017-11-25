using System;
using System.Linq.Expressions;

namespace DesignPatternsBuilder.zad2.Interfaces
{
    public interface ITestStepsDefinition<TExpressionParentClass> : ITestFlowBuilder where TExpressionParentClass : class
    {
        #region Public Methods

        TestFlowBuilder<TExpressionParentClass> DefineStep(Expression<Func<bool>> expression);

        #endregion
    }
}