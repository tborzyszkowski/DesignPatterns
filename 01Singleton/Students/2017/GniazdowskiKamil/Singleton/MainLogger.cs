using System;

namespace Singleton
{
    public class MainLogger : LoggerBase<MainLogger>
    {
        protected override string Path
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "/Logs/Main/";
            }
            set { }
        }
    }
}
