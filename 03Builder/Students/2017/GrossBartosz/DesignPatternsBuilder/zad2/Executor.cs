using System;
using System.Linq;
using System.Linq.Expressions;
using DesignPatternsBuilder.zad2.Interfaces;

namespace DesignPatternsBuilder.zad2
{
    public class Executor
    {
        public static bool Execute(ITestFlowBuilder testFlowBuilder)
        {
            var stepSuccessful = true;

            var stepsGroups = testFlowBuilder.GetTestSteps().ToArray();

            foreach (var @group in stepsGroups)
            {

                for (var stepNumber = 0; stepNumber < @group.Steps.Count;)
                {
                    var step = @group.Steps[stepNumber];
                    stepSuccessful = ExecuteStep(step);

                    if (stepSuccessful)
                    {
                        stepNumber++;
                    }
                }
            }

            return stepSuccessful;
        }

        private static bool ExecuteCondition(Expression<Func<bool>> conditionExpression)
        {
            var condition = conditionExpression.Compile();

            return condition();
        }

        public static bool Process(TestStep testStep)
        {
            return ExecuteCondition(testStep.Expression);
        }

        private static bool ExecuteStep(TestStep step)
        {
            var stepSuccessful = true;
            var result = Process(step);

            return stepSuccessful;
        }
    }
}
