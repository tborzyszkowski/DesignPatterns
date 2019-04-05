using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class ChildOneSingleton : SingletonBase
    {
        protected ChildOneSingleton() : base()
        {

        }

        public override string TestMethod()
        {
            return $"Test method from ChildOneSingleton class.";
        }
    }
}
