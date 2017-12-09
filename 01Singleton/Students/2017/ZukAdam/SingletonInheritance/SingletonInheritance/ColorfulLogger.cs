using System;

namespace SingletonTest
{
    public class ColorfulLogger : Logger
    {
        private ColorfulLogger() {}

        public new static Logger GetLoggerInstance()
        {
            if (LoggerInstance == null || LoggerInstance.GetType() != typeof(ColorfulLogger))
            {
                LoggerInstance = new ColorfulLogger();
            }
            return LoggerInstance;
        }

        public override void Log(string text)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
        }
    }
}
