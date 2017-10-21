using System;
using SingletonSerialization.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace SingletonSerialization
{
    public class Logger : ILogger
    {
        public ConsoleColor BackColor { get; set; }
        public ConsoleColor ForeColor { get; set; }

        private static object locker;

        protected static ILogger LoggerInstance;

        protected Logger()
        {
            this.ForeColor = ConsoleColor.Gray;
            this.BackColor = ConsoleColor.Black;
            locker = new object();
        }

        public static ILogger GetLoggerInstance()
        {
            if (LoggerInstance == null)
            {
                LoggerInstance = new Logger();
            }
            return LoggerInstance;
        }

        public virtual void Log(string text)
        {
            Console.BackgroundColor = this.BackColor;
            Console.ForegroundColor = this.ForeColor;
            Console.WriteLine(text);
        }

        public static void Deserialize(string fileName)
        {
            lock (locker)
            {
                if (LoggerInstance == null)
                {
                    LoggerInstance = DeserializeFromFile(fileName);
                }
            }
        }

        public bool Serialize(string fileName)
        {
            using(var writer = new StreamWriter(Environment.CurrentDirectory + @"\" + fileName))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(Logger));
                    serializer.Serialize(writer, GetLoggerInstance());

                    return true;
                }
                catch (Exception e)
                {
                    this.Log(e.Message);
                    return false;
                }
            }
        }

        private static ILogger DeserializeFromFile(string fileName)
        {
            ILogger result = null;

            using (var reader = new StreamReader(Environment.CurrentDirectory + @"\" + fileName))
            {
                var serializer = new XmlSerializer(typeof(Logger));
                result = serializer.Deserialize(reader) as Logger;
            }

            return result;
        }

        public static void DropInstance()
        {
            LoggerInstance = null;
        }
    }
}
