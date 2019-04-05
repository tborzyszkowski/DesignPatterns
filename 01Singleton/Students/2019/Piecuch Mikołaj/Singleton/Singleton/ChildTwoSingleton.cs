using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class ChildTwoSingleton : SingletonBase
    {
        protected ChildTwoSingleton() : base()
        {

        }

        public override string TestMethod()
        {
            return $"Test method from ChildTwoSingleton class.";
        }
    }
}
