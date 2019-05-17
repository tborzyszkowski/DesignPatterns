using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singleton;

namespace Singleton
{
    public class Second_Child : SingletonInheritance<Second_Child>
    {
        protected Second_Child() : base()
        {

        }
    }
}