using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.AbstractFactoryIsBetter
{
    public class WarningLogFactory : LogFactory
    {
        private static readonly Lazy<WarningLogFactory> factory = new Lazy<WarningLogFactory>(() => new WarningLogFactory());

        public new static LogFactory GetFactory()
        {
            return factory.Value;
        }

        public override Log CreateLog(String msg)
        {
            return new WarningLog(msg);
        }
    }
}
