using System;

namespace Singleton
{
    class PrivateLogger : LoggerBase<PrivateLogger>
    {
        protected override string Path
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "/Logs/Private/";
            }
            set { }
        }
    }
}
