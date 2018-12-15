using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.AbstractFactoryIsBetter
{
    public abstract class LogFactory
    {
        public abstract Log CreateLog(String msg);

        public static LogFactory GetFactory() { return null; }
    }
}
