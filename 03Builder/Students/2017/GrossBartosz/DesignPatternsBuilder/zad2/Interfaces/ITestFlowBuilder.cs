using System.Collections.Generic;

namespace DesignPatternsBuilder.zad2.Interfaces
{
    public interface ITestFlowBuilder
    {
        #region Public Methods

        /// <summary>
        /// Method returns collection of test case steps.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{TestStep}" />.
        /// </returns>
        IEnumerable<TestStepsGroup> GetTestSteps();

        #endregion
    }
}