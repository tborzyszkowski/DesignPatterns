using System.Collections.Generic;

namespace DesignPatternsBuilder.zad2
{
    public class TestStepsGroup
    {
        #region Properties and Indexers

        /// <summary>
        /// Gets or sets the steps - order is very important!.
        /// </summary>
        public List<TestStep> Steps { get; set; }

        #endregion
    }
}