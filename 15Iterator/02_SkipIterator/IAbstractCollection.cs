using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SkipIterator {
    interface IAbstractCollection {
        Iterator CreateIterator();
    }
}
