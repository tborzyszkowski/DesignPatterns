using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class GenTwoSingleton : GenericSingleton<GenTwoSingleton>
    {
        private GenTwoSingleton() : base() { }
    }
}
