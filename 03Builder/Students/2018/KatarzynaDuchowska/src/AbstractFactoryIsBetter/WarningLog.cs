using System;
using System.Net.Http;

namespace Builder.AbstractFactoryIsBetter
{
    public class WarningLog : Log
    {
        public WarningLog(String msg)
        {
            message = msg;
            type = "WARN";
        }
    }
}