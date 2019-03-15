using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class DerivedSingleton2 : LazySingleton<DerivedSingleton2>
    {
        public DerivedSingleton2() : base()
        {

        }
    }
}
