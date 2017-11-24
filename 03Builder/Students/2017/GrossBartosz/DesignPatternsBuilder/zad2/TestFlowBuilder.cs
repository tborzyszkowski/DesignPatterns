using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DesignPatternsBuilder.zad2.Interfaces;

namespace DesignPatternsBuilder.zad2
{
    public class TestFlowBuilder<TExpressionParentClass> : ITestStepsDefinition<TExpressionParentClass> where TExpressionParentClass : class
    {
        private readonly List<TestStepsGroup> stepsGroups = new List<TestStepsGroup>();
        private TestStep CurrentStep { get; set; }

        public TestFlowBuilder<TExpressionParentClass> DefineStep(Expression<Func<bool>> expression)
        {
            this.CurrentStep = new TestStep(expression);

            this.AddStep(this.CurrentStep);

            return this;
        }

        private void AddStep(TestStep step)
        {
            this.stepsGroups.Add(new TestStepsGroup {Steps = new List<TestStep> {step}});
        }


        public IEnumerable<TestStepsGroup> GetTestSteps()
        {
            return this.stepsGroups;
        }
    }
}