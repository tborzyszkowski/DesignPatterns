using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class DerivedSingletonA : LazySingleton<DerivedSingletonA>
    {
        public DerivedSingletonA() : base()
        {

        }
    }
}
