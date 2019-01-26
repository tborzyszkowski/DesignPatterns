using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.AbstractFactoryIsBetter
{
    public class ErrorLogFactory : LogFactory
    {
        private static readonly Lazy<ErrorLogFactory> factory = new Lazy<ErrorLogFactory>(() => new ErrorLogFactory());

        public new static LogFactory GetFactory()
        {
            return factory.Value;
        }

        public override Log CreateLog(string msg)
        {
            return new ErrorLog(msg);
        }
    }
}
