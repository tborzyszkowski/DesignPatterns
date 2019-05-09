using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singleton;

namespace Singleton
{
    public class Child : SingletonInheritance<Child>
    {
        protected Child() : base()
        {

        }
    }
}
